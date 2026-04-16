using DMOS.Core.Info;
using DMOS.Core.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMOS.Extensions
{
    public static class LogLevelExtensions
    {
        private static Dictionary<LogLevel, ConsoleColor> _levelColorMap = new()
        {
            { LogLevel.Information, ConsoleColor.Green },
            { LogLevel.Warning, ConsoleColor.Yellow },
            { LogLevel.Error, ConsoleColor.Red },
            { LogLevel.Fatal, ConsoleColor.DarkRed }
        };

        private static Dictionary<LogLevel, string> _levelNameMap = new()
        {
            { LogLevel.Information, "INFO" },
            { LogLevel.Warning, "WARN" },
            { LogLevel.Error, "FAIL" },
            { LogLevel.Fatal, "FERR" }
        };

        /// <summary>
        /// Gets a log level's color.
        /// </summary>
        /// <param name="stage">The log level.</param>
        /// <returns>The level's color.</returns>
        public static ConsoleColor GetColor(this LogLevel stage)
            => _levelColorMap[stage];

        /// <summary>
        /// Gets a log level's name.
        /// </summary>
        /// <param name="stage">The log level.</param>
        /// <returns>The level's name.</returns>
        public static string GetName(this LogLevel stage)
            => _levelNameMap[stage];
    }
}
