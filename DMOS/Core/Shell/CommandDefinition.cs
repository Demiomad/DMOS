using DMOS.Core.Shell.Contexts;
using DMOS.Core.Shell.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMOS.Core.Shell
{
    /// <summary>
    /// Represents a command's definition.
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
        /// The usage of this command.
        /// Square brackets mean optional arguments, while angled brackets mean required arguments.
        /// </summary>
        public string? Usage { get; set; }

        /// <summary>
        /// The command's aliases.
        /// </summary>
        public string[]? Aliases { get; set; }

        /// <summary>
        /// The action that gets executed once the command runs.
        /// </summary>
        public Func<CommandContext, CommandResult>? OnRun { get; set; }
    }
}
