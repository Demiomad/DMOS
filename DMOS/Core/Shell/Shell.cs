using System;
using System.Collections.Generic;
using System.Text;
using DMOS.Core.Logging;

namespace DMOS.Core.Shell
{
    /// <summary>
    /// Represents the system shell.
    /// </summary>
    public class Shell
    {
        /// <summary>
        /// The list of the shell's commands.
        /// </summary>
        public List<CommandDefinition> Commands { get; set; } = [];

        public Shell()
        {
            Commands.Add(new CommandDefinition()
            {
                Name = "echo",
                Description = "Displays a message.",
                Execute = ctx =>
                {
                    Console.WriteLine(string.Join(' ', ctx.Args.ToArray()));
                    
                    return CommandResult.Success;
                }
            });

            Commands.Add(new CommandDefinition()
            {
                Name = "help",
                Description = "Displays all available commands.",
                Execute = ctx =>
                {
                    foreach (var cmd in Commands)
                    {
                        Console.WriteLine($"{cmd.Name} - {cmd.Description}");
                    }

                    return CommandResult.Success;
                }
            });

            Commands.Add(new CommandDefinition()
            {
                Name = "clear",
                Aliases = ["cls"],
                Description = "Clears the console.",
                Execute = ctx =>
                {
                    Console.Clear();
                    return CommandResult.Success;
                }
            });
        }

        /// <summary>
        /// Runs a command using the provided input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>The command's result.</returns>
        public CommandResult RunCommand(string input)
        {
            var (name, ctx) = Parser.ParseContext(input);

            var cmd = Commands.FirstOrDefault(c => c.Name!.Equals(name, StringComparison.CurrentCultureIgnoreCase) ||
                    c.Aliases.Contains(name.ToLower()));

            if (cmd == null)
            {
                return new CommandResult()
                {
                    ExitCode = -1,
                    Message = $"The command \"{name}\" was not found."
                };
            }

            return cmd.Execute(ctx);
        }

        /// <summary>
        /// Runs the shell once.
        /// </summary>
        public void Run()
        {
            Console.Write("> ");

            var input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
                return;

            var result = RunCommand(input);

            if (!result.Successful)
                Kernel.Logger.Log(LogLevel.Error, result.Message);
        }
    }
}
