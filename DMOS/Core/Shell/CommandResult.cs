using System;
using System.Collections.Generic;
using System.Text;

namespace DMOS.Core.Shell
{
    /// <summary>
    /// Represents a command's result.
    /// </summary>
    public class CommandResult
    {
        /// <summary>
        /// The command's exit code.
        /// </summary>
        public int ExitCode { get; set; }

        /// <summary>
        /// The message, not necessary if an error didn't occur.
        /// </summary>
        public string? Message { get; set; }

        /// <summary>
        /// Whether the command exited successfully. (exit code is 0)
        /// </summary>
        public bool Successful => ExitCode == 0;

        /// <summary>
        /// The success command result.
        /// </summary>
        public static CommandResult Success { get; } = new CommandResult()
        {
            ExitCode = 0
        };
    }
}
