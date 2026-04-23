using System;
using System.Collections.Generic;
using System.Text;

namespace DMOS.Core.System.Formatting
{
    /// <summary>
    /// Custom string formatter for the standard output system.
    /// </summary>
    public static class StringFormatter
    {
        private const char FmtSpecChar = '%';
        
        /// <summary>
        /// Formats a string.
        /// </summary>
        /// <param name="fmt">The string format. (e.g. "Hello, %!")</param>
        /// <param name="args">The arguments.</param>
        /// <returns>The formatted string.</returns>
        public static string Format(string? fmt, params object?[] args)
        {
            if (string.IsNullOrEmpty(fmt) || args.Length == 0)
                return string.Empty;

            var sb = new StringBuilder();
            var argIndex = 0;

            for (int i = 0; i < fmt.Length; i++)
            {
                var ch = fmt[i];

                if (ch == FmtSpecChar)
                {
                    // so we can actually print that char
                    if (i + 1 < fmt.Length && fmt[i + 1] == FmtSpecChar)
                    {
                        sb.Append(FmtSpecChar);
                        i++;
                        continue;
                    }

                    if (argIndex >= args.Length)
                        continue;

                    sb.Append(args[argIndex]);
                    argIndex++;
                }
                else
                    sb.Append(ch);
            }

            return sb.ToString();
        }
    }
}
