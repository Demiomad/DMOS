using System;
using System.Collections.Generic;
using System.Text;

namespace DMOS.Core.Shell
{
    /// <summary>
    /// Represents a command definition.
    /// </summary>
    public class CommandDefinition
    {
        /// <summary>
        /// The command's name.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// The command's description.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// The action to execute.
        /// </summary>
        public Func<CommandContext, CommandResult> Execute { get; set; }
    }
}
