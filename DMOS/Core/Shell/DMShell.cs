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
                    Console.WriteLine(string.Join(' ', ctx.Args.ToArray()));
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

            var cmd = Commands.FirstOrDefault(c => c.Name!.Equals(name, StringComparison.CurrentCultureIgnoreCase) 
                    || c.Aliases.Contains(name));

            if (cmd == null)
                return new CommandResult()
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
            {
                // TODO: Implement logger
            }
        }
    }
}
