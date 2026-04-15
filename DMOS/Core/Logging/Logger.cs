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
        /// The logger's context.
        /// </summary>
        public string? Context { get; set; }

        /// <summary>
        /// Logs a message to the console.
        /// </summary>
        /// <param name="level">The log level.</param>
        /// <param name="message">The message</param>
        public void Log(LogLevel level, string message)
        {
            Console.ForegroundColor = level switch
            {
                LogLevel.Error => ConsoleColor.Red,
                LogLevel.Warn => ConsoleColor.Yellow,
                LogLevel.Info => ConsoleColor.Cyan,
                LogLevel.Fatal => ConsoleColor.DarkRed,
                _ => ConsoleColor.White,
            };

            Console.Write($"[ {Context}, {level.ToString().ToUpper()} ] ");
            Console.ResetColor();

            Console.WriteLine(message);
        }
    }
}
