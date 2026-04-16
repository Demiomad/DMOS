using DMOS.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMOS.Core.Logging
{
    /// <summary>
    /// Represents a logger.
    /// </summary>
    public class Logger
    {
        /// <summary>
        /// The list of entries.
        /// </summary>
        public List<string> Entries { get; private set; } = [];

        /// <summary>
        /// Logs a message to the logger.
        /// </summary>
        /// <param name="level">The log level.</param>
        /// <param name="message">The log message.</param>
        public void Log(LogLevel level, string? message)
        {
            if (!string.IsNullOrEmpty(message))
                Entries.Add(message);

            Console.ForegroundColor = level.GetColor();
            Console.Write($"[ {level.GetName()} ] ");
            Console.ResetColor();
            Console.WriteLine(message);
        }
    }
}
