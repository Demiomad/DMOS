using System;
using System.Collections.Generic;
using System.Text;

namespace DMOS.Core.Shell.Utils
{
    /// <summary>
    /// Represents a command's result.
    /// </summary>
    public class CommandResult
    {
        /// <summary>
        /// The exit code.
        /// </summary>
        public int ExitCode { get; set; }

        /// <summary>
        /// The output message.
        /// </summary>
        public string? Message { get; set; }

        /// <summary>
        /// Whether the command exited successfully.
        /// </summary>
        public bool Successful => ExitCode == 0;

        /// <summary>
        /// The success command result.
        /// </summary>
        public static CommandResult Success { get; set; } = new()
        {
            ExitCode = 0
        };
    }
}
