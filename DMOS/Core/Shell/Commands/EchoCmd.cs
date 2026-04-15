using DMOS.Core.Shell.Arguments;
using DMOS.Core.Shell.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMOS.Core.Shell.Commands
{
    public class EchoCmd : Command
    {
        public override List<CommandArgument> Args { get; } = [
            new PositionalArgument()
            {
                Name = "message",
                Description = "The message to display.",
                Position = 0,
                Required = false,
                Value = string.Empty
            }    
        ];

        public override string Name { get; } = "echo";

        public override string Description { get; } = "Displays a message.";

        public override CommandResult Run()
        {
            var msg = GetArg("message")?.Value;
            Console.WriteLine(msg);

            return new CommandResult()
            {
                ExitCode = 0
            };
        }
    }
}
