using System.Diagnostics;
using CishCompiler.CodeGen;
using CishCompiler.Lexing;
using CishCompiler.Nodes;
using CishCompiler.Parsing;
using CishCompiler.SemanticAnalysis;

namespace CishRunner
{
    public static class Program
    {
        // The parser has no error recovery and loops forever on a syntax error, so every
        // pipeline run is bounded by this timeout instead of hanging the runner.
        const int PipelineTimeoutMs = 10000;

        public static int Main(string[] args)
        {
            Options? options = Options.Parse(args);
            if (options == null)
            {
                PrintUsage();
                return 1;
            }
            if (options.All)
            {
                return RunAll(options);
            }
            string? source = ResolveSource(options.Source!);
            if (source == null)
            {
                Console.Error.WriteLine($"Could not find '{options.Source}' as a file or as a sample in {SamplesDir() ?? "(samples directory not found)"}.");
                return 1;
            }
            PipelineResult result = RunPipeline(File.ReadAllLines(source));
            Report(source, result, options);
            return Finish(source, result, options);
        }

        static void PrintUsage()
        {
            Console.WriteLine("Usage: CishRunner <file.cish | sample-name> [--tokens] [--out <path.il>] [--assemble] [--run]");
            Console.WriteLine("       CishRunner --all [--assemble]");
            Console.WriteLine();
            Console.WriteLine("  <sample-name>  a file in CishCompiler/CishSmallProjects, with or without .cish");
            Console.WriteLine("  --tokens       also print the lexer output");
            Console.WriteLine("  --out <path>   write the generated IL to <path>");
            Console.WriteLine("  --assemble     write the IL and assemble it with ilasm.exe (.NET Framework)");
            Console.WriteLine("  --run          assemble, then run the produced .exe with stdin forwarded");
            Console.WriteLine("  --all          run every sample and print a one-line summary per sample");
            Console.WriteLine();
            Console.WriteLine("Exit codes: 0 ok, 1 pipeline or semantic failure, 2 pipeline timeout, 3 ilasm failure");
        }

        sealed class Options
        {
            public string? Source;
            public bool All;
            public bool ShowTokens;
            public bool Assemble;
            public bool Run;
            public string? OutPath;

            public static Options? Parse(string[] args)
            {
                Options options = new Options();
                for (int i = 0; i < args.Length; i++)
                {
                    string arg = args[i];
                    if (arg == "--all")
                    {
                        options.All = true;
                    }
                    else if (arg == "--tokens")
                    {
                        options.ShowTokens = true;
                    }
                    else if (arg == "--assemble")
                    {
                        options.Assemble = true;
                    }
                    else if (arg == "--run")
                    {
                        options.Assemble = true;
                        options.Run = true;
                    }
                    else if (arg == "--out")
                    {
                        if (i + 1 >= args.Length)
                        {
                            return null;
                        }
                        i++;
                        options.OutPath = args[i];
                    }
                    else if (arg.StartsWith("--"))
                    {
                        return null;
                    }
                    else if (options.Source == null)
                    {
                        options.Source = arg;
                    }
                    else
                    {
                        return null;
                    }
                }
                if (options.Source == null && !options.All)
                {
                    return null;
                }
                return options;
            }
        }

        sealed class PipelineResult
        {
            public List<TokenNode>? Tokens;
            public AbstractSyntaxTree? Ast;
            public List<ErrorData>? SemanticErrors;
            public List<string>? Il;
            public volatile string Stage = "lex";
            public string? Failure;
            public bool TimedOut;
        }

        static PipelineResult RunPipeline(string[] lines)
        {
            PipelineResult result = new PipelineResult();
            Task work = Task.Run(() =>
            {
                try
                {
                    result.Stage = "lex";
                    result.Tokens = Lexer.TokenizeInputCode(lines);
                    result.Stage = "parse";
                    result.Ast = Parser.ParseFile(result.Tokens);
                    result.Stage = "semantic";
                    result.SemanticErrors = SemanticAnalysiser.Analyze(result.Ast);
                    if (result.SemanticErrors.Count > 0)
                    {
                        return;
                    }
                    result.Stage = "codegen";
                    result.Il = CodeGeneration.GenerateMainMethod(result.Ast.Root);
                }
                catch (Exception ex)
                {
                    result.Failure = ex.GetType().Name + ": " + ex.Message;
                }
            });
            if (!work.Wait(PipelineTimeoutMs))
            {
                result.TimedOut = true;
            }
            return result;
        }

        static void Report(string source, PipelineResult result, Options options)
        {
            Console.WriteLine($"== Source: {source}");
            if (options.ShowTokens && result.Tokens != null)
            {
                PrintTokens(result.Tokens);
            }
            if (result.Ast != null)
            {
                Console.WriteLine("== AST");
                PrintAst(result.Ast.Root, "", true, true);
            }
            if (result.SemanticErrors != null)
            {
                Console.WriteLine($"== Semantic analysis: {result.SemanticErrors.Count} error(s)");
                foreach (ErrorData error in result.SemanticErrors)
                {
                    Console.WriteLine($"  line {error.LineNumber + 1}, token {error.TokenNumber}: {error.ErrorMessage}");
                }
            }
            if (result.Il != null)
            {
                Console.WriteLine($"== IL ({result.Il.Count} lines)");
                foreach (string line in result.Il)
                {
                    Console.WriteLine(line);
                }
            }
            if (result.TimedOut)
            {
                Console.WriteLine($"== TIMEOUT: stage '{result.Stage}' did not finish within {PipelineTimeoutMs / 1000} s. The parser has no error recovery and loops forever on a syntax error.");
            }
            else if (result.Failure != null)
            {
                Console.WriteLine($"== FAILED in stage '{result.Stage}': {result.Failure}");
            }
        }

        static int Finish(string source, PipelineResult result, Options options)
        {
            if (result.TimedOut)
            {
                return 2;
            }
            if (result.Il == null)
            {
                return 1;
            }
            if (options.OutPath == null && !options.Assemble)
            {
                return 0;
            }
            string ilPath = options.OutPath ?? DefaultIlPath(source);
            WriteIl(ilPath, result.Il);
            Console.WriteLine($"== IL written to {ilPath}");
            if (!options.Assemble)
            {
                return 0;
            }
            string? exePath = Assemble(ilPath, true, out string ilasmError);
            if (exePath == null)
            {
                Console.WriteLine(ilasmError.Trim());
                return 3;
            }
            if (!options.Run)
            {
                return 0;
            }
            RunExe(exePath);
            return 0;
        }

        static int RunAll(Options options)
        {
            string? samples = SamplesDir();
            if (samples == null)
            {
                Console.Error.WriteLine("Samples directory not found. CishCompiler.sln must be above the runner binary or the current directory.");
                return 1;
            }
            string[] files = Directory.GetFiles(samples, "*.cish").OrderBy(f => f).ToArray();
            Console.WriteLine($"{"Sample",-18} {"Lex",-14} {"Parse",-9} {"Semantic",-11} {"IL",-10} {"ilasm",-6}");
            List<string> details = new List<string>();
            int failures = 0;
            foreach (string file in files)
            {
                string name = Path.GetFileNameWithoutExtension(file);
                PipelineResult result = RunPipeline(File.ReadAllLines(file));
                string lex = "-";
                if (result.Tokens != null)
                {
                    int bad = result.Tokens.Count(t => t is ErrorNode);
                    if (bad == 0)
                    {
                        lex = "ok";
                    }
                    else
                    {
                        lex = $"{bad} bad token(s)";
                    }
                }
                string parse = "-";
                if (result.Ast != null)
                {
                    parse = "ok";
                }
                else if (result.TimedOut)
                {
                    parse = "TIMEOUT";
                }
                else if (result.Failure != null && result.Stage == "parse")
                {
                    parse = "FAIL";
                }
                string semantic = "-";
                if (result.SemanticErrors != null)
                {
                    semantic = $"{result.SemanticErrors.Count} error(s)";
                }
                else if (result.Failure != null && result.Stage == "semantic")
                {
                    semantic = "FAIL";
                }
                string il = "-";
                if (result.Il != null)
                {
                    il = $"{result.Il.Count} lines";
                }
                else if (result.Failure != null && result.Stage == "codegen")
                {
                    il = "FAIL";
                }
                string ilasm = "-";
                if (options.Assemble && result.Il != null)
                {
                    string ilPath = DefaultIlPath(file);
                    WriteIl(ilPath, result.Il);
                    if (Assemble(ilPath, false, out string ilasmError) == null)
                    {
                        ilasm = "FAIL";
                        details.Add($"{name}: ilasm failed: {FirstErrorLine(ilasmError)}");
                    }
                    else
                    {
                        ilasm = "ok";
                    }
                }
                bool ok = result.Il != null && ilasm != "FAIL";
                if (!ok)
                {
                    failures++;
                }
                if (result.TimedOut)
                {
                    details.Add($"{name}: timed out in stage '{result.Stage}'");
                }
                else if (result.Failure != null)
                {
                    details.Add($"{name}: {result.Failure}");
                }
                Console.WriteLine($"{name,-18} {lex,-14} {parse,-9} {semantic,-11} {il,-10} {ilasm,-6}");
            }
            foreach (string detail in details)
            {
                Console.WriteLine(detail);
            }
            Console.WriteLine($"{files.Length - failures}/{files.Length} sample(s) compiled.");
            if (failures == 0)
            {
                return 0;
            }
            return 1;
        }

        static void PrintTokens(List<TokenNode> tokens)
        {
            Console.WriteLine("== Tokens (whitespace omitted, line:token)");
            foreach (TokenNode token in tokens)
            {
                if (token is SpaceNode)
                {
                    continue;
                }
                string marker = "";
                if (token is ErrorNode)
                {
                    marker = "   <-- unrecognised";
                }
                Console.WriteLine($"  {token.LineNumber + 1,3}:{token.TokenNumber,-3} {token.GetType().Name,-32} {token.Value}{marker}");
            }
        }

        static void PrintAst(ASTNode node, string prefix, bool isLast, bool isRoot)
        {
            string branch = "";
            string childPrefix = prefix;
            if (!isRoot)
            {
                if (isLast)
                {
                    branch = "\\-- ";
                    childPrefix = prefix + "    ";
                }
                else
                {
                    branch = "|-- ";
                    childPrefix = prefix + "|   ";
                }
            }
            string label = node.Node.GetType().Name;
            if (!node.Value.IsEmpty)
            {
                label += " '" + node.Value + "'";
            }
            Console.WriteLine(prefix + branch + label);
            for (int i = 0; i < node.Children.Count; i++)
            {
                PrintAst(node.Children[i], childPrefix, i == node.Children.Count - 1, false);
            }
        }

        static string DefaultIlPath(string source)
        {
            return Path.Combine(Path.GetTempPath(), "CishRunner", Path.GetFileNameWithoutExtension(source) + ".il");
        }

        static void WriteIl(string ilPath, List<string> il)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(ilPath)!);
            File.WriteAllLines(ilPath, il);
        }

        static string FirstErrorLine(string ilasmOutput)
        {
            foreach (string line in ilasmOutput.Split('\n'))
            {
                if (line.Contains(" error : "))
                {
                    return line.Trim();
                }
            }
            return ilasmOutput.Trim();
        }

        static string? Assemble(string ilPath, bool verbose, out string errorOutput)
        {
            errorOutput = "";
            string? ilasm = FindIlasm();
            if (ilasm == null)
            {
                errorOutput = "ilasm.exe not found under %WINDIR%\\Microsoft.NET\\Framework64\\v4.0.30319; cannot assemble.";
                return null;
            }
            string exePath = Path.ChangeExtension(ilPath, ".exe");
            ProcessStartInfo startInfo = new ProcessStartInfo(ilasm)
            {
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false
            };
            startInfo.ArgumentList.Add("/nologo");
            startInfo.ArgumentList.Add("/quiet");
            startInfo.ArgumentList.Add("/exe");
            startInfo.ArgumentList.Add(ilPath);
            startInfo.ArgumentList.Add("/output=" + exePath);
            using Process process = Process.Start(startInfo)!;
            string output = process.StandardOutput.ReadToEnd() + process.StandardError.ReadToEnd();
            process.WaitForExit();
            if (process.ExitCode != 0)
            {
                errorOutput = output;
                if (verbose)
                {
                    Console.WriteLine($"== ilasm FAILED for {ilPath}");
                }
                return null;
            }
            if (verbose)
            {
                Console.WriteLine($"== Assembled to {exePath}");
            }
            return exePath;
        }

        static void RunExe(string exePath)
        {
            Console.WriteLine("== Running (stdin is forwarded to the program)");
            using Process process = Process.Start(new ProcessStartInfo(exePath) { UseShellExecute = false })!;
            process.WaitForExit();
            Console.WriteLine($"== Program exited with code {process.ExitCode}");
        }

        static string? FindIlasm()
        {
            string windir = Environment.GetEnvironmentVariable("WINDIR") ?? @"C:\Windows";
            string[] candidates =
            {
                Path.Combine(windir, "Microsoft.NET", "Framework64", "v4.0.30319", "ilasm.exe"),
                Path.Combine(windir, "Microsoft.NET", "Framework", "v4.0.30319", "ilasm.exe")
            };
            foreach (string candidate in candidates)
            {
                if (File.Exists(candidate))
                {
                    return candidate;
                }
            }
            return null;
        }

        static string? ResolveSource(string arg)
        {
            if (File.Exists(arg))
            {
                return Path.GetFullPath(arg);
            }
            string? samples = SamplesDir();
            if (samples == null)
            {
                return null;
            }
            string candidate = Path.Combine(samples, arg);
            if (File.Exists(candidate))
            {
                return candidate;
            }
            candidate = Path.Combine(samples, arg + ".cish");
            if (File.Exists(candidate))
            {
                return candidate;
            }
            return null;
        }

        static string? SamplesDir()
        {
            string? root = FindRepoRoot();
            if (root == null)
            {
                return null;
            }
            return Path.Combine(root, "CishCompiler", "CishSmallProjects");
        }

        static string? FindRepoRoot()
        {
            string[] starts = { AppContext.BaseDirectory, Environment.CurrentDirectory };
            foreach (string start in starts)
            {
                DirectoryInfo? dir = new DirectoryInfo(start);
                while (dir != null)
                {
                    if (File.Exists(Path.Combine(dir.FullName, "CishCompiler.sln")))
                    {
                        return dir.FullName;
                    }
                    dir = dir.Parent;
                }
            }
            return null;
        }
    }
}
