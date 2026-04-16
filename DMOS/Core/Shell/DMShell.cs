using Cosmos.Kernel.Core.Runtime;
using Cosmos.Kernel.Core.Scheduler;
using Cosmos.Kernel.HAL;
using Cosmos.Kernel.System.Graphics;
using DMOS.Core.Info;
using DMOS.Core.Logging;
using DMOS.Core.Shell.Parsing;
using DMOS.Core.Shell.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMOS.Core.Shell
{
    /// <summary>
    /// Represents the system shell.
    /// </summary>
    public class DMShell
    {
        /// <summary>
        /// The list of commands.
        /// </summary>
        public List<CommandDefinition> Commands { get; set; } = [];

        public DMShell()
        {
            Commands.Add(new CommandDefinition()
            {
                Name = "echo",
                Description = "Displays a message.",
                Usage = "echo [message]",
                Aliases = ["write", "print"],
                OnRun = ctx =>
                {
                    if (ctx.Args.Count == 0)
                        Console.WriteLine();
                    else
                        Console.WriteLine(string.Join(' ', ctx.Args.ToArray()));

                    return CommandResult.Success;
                }
            });

            Commands.Add(new CommandDefinition()
            {
                Name = "help",
                Description = "Displays help infomration.",
                Usage = "help [command]",
                Aliases = ["write", "print"],
                OnRun = ctx =>
                {
                    static void PrintCommand(string? cmd, string? value)
                    {
                        Console.Write("  ");
                        Console.Write(cmd!.PadRight(16));
                        Console.WriteLine(value);
                    }

                    if (ctx.TryGetArg(0, out var name))
                    {
                        var cmd = Commands.FirstOrDefault(c => c.Name!.Equals(name, StringComparison.CurrentCultureIgnoreCase));

                        if (cmd == null)
                            return new CommandResult()
                            {
                                ExitCode = -1,
                                Message = $"\"{name}\" is not a valid command."
                            };

                        var sb = new StringBuilder();

                        sb.AppendLine($"{cmd.Name}:");
                        sb.AppendLine($"\t{cmd.Description}");
                        sb.AppendLine();
                        sb.AppendLine($"\tUsage: {cmd.Usage}");

                        if (cmd.Aliases.Length != 0)
                        {
                            sb.AppendLine();
                            sb.AppendLine("\tAliases:");

                            foreach (var alias in cmd.Aliases)
                                sb.AppendLine($"\t\t- {alias}");
                        }

                        Console.Write(sb.ToString());
                    }
                    else
                    {
                        foreach (var cmd in Commands)
                        {
                            PrintCommand(cmd.Name, cmd.Description);
                        }
                    }

                    return CommandResult.Success;
                }
            });

            Commands.Add(new CommandDefinition()
            {
                Name = "clear",
                Description = "Clears the screen.",
                Usage = "clear",
                Aliases = ["cls", "clear"],
                OnRun = ctx =>
                {
                    Console.Clear();
                    return CommandResult.Success;
                }
            });

            Commands.Add(new CommandDefinition()
            {
                Name = "sysfetch",
                Description = "Displays system information.",
                Usage = "sysfetch",
                Aliases = ["sysinfo", "neofetch"],
                OnRun = ctx =>
                {
                    static void PrintInfoLine(string label, string value)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(label.PadRight(16));
                        Console.ResetColor();

                        Console.WriteLine(value);
                    }

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(OSInfo.FullString);
                    Console.ResetColor();
                    PrintInfoLine("Platform", PlatformHAL.PlatformName);
                    PrintInfoLine("Date & Time", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
                    
                    var defCons = KernelConsole.Default!;
                    PrintInfoLine("Console", $"{defCons.Cols}x{defCons.Rows} chars");

                    if (defCons.IsAvailable)
                    {
                        var canvas = defCons.Canvas;
                        PrintInfoLine("Framebuffer",
                            $"{canvas.Mode.Width}x{canvas.Mode.Height}@{(int)canvas.Mode.ColorDepth} {canvas.RefreshRate} Hz ({canvas.Name()})");
                    }
                    else
                        PrintInfoLine("Framebuffer", "Unavailable");

                    return CommandResult.Success;
                }
            });
        }

        /// <summary>
        /// Runs a command using the given input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>The command's result.</returns>
        public CommandResult? RunCommand(string input)
        {
            var (name, ctx) = Parser.GetContext(input);

            if (ctx == null)
                return new CommandResult
                {
                    ExitCode = -1,
                    Message = "Could not create command context"
                };

            var cmd = Commands.FirstOrDefault(c => c.Name!.Equals(name, StringComparison.CurrentCultureIgnoreCase) 
                    || c.Aliases.Contains(name));

            if (cmd == null)
                return new CommandResult
                {
                    ExitCode = -1,
                    Message = $"\"{name}\" is not a valid command."
                };

            return cmd?.OnRun?.Invoke(ctx!);
        }

        private void WritePrompt()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("dmos");
            Console.ResetColor();
            Console.Write("@");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("~");
            Console.ResetColor();
            Console.Write("$ ");
        }

        /// <summary>
        /// Runs the shell once.
        /// </summary>
        public void Run()
        {
            WritePrompt();
            var input = Console.ReadLine();

            if (string.IsNullOrEmpty(input)) return;

            var result = RunCommand(input);

            if (result != null && result.ExitCode != 0)
                Shared.Logger?.Log(LogLevel.Error, result.Message);
        }
    }
}
