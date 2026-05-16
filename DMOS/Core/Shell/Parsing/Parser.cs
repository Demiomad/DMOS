using DMOS.Core.Shell.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMOS.Core.Shell.Parsing
{
    /// <summary>
    /// Represents a parser.
    /// </summary>
    public static class Parser
    {
        /// <summary>
        /// Splits the string by whitespace, while also respecting quoted groups.
        /// </summary>
        /// <param name="input">The user input.</param>
        /// <returns>The parsed array.</returns>
        public static string[] SplitQuotes(string input)
        {
            var current = new StringBuilder();
            var output = new List<string>();
            var insideQuotes = false;

            for (int i = 0; i < input.Length; i++)
            {
                var ch = input[i];

                if (ch == '\'' || ch == '"')
                    insideQuotes = !insideQuotes;
                else if (char.IsWhiteSpace(ch))
                {
                    if (!insideQuotes)
                    {
                        output.Add(current.ToString());
                        current.Clear();
                    }
                    else
                        current.Append(ch);
                }
                else
                    current.Append(ch);
            }

            output.Add(current.ToString());

            return output.ToArray();
        }

        public static (string name, CommandContext? ctx) GetContext(string input)
        {
            const string FlagPrefix = "--";

            if (string.IsNullOrEmpty(input))
                return (string.Empty, null);

            var parts = SplitQuotes(input);
            var name = parts[0];
            var ctx = new CommandContext();

            for (int i = 1; i < parts.Length; i++)
            {
                var part = parts[i];

                if (part.StartsWith(FlagPrefix))
                {
                    var flagName = part[FlagPrefix.Length..];
                    ctx.Flags[flagName] = true;
                }
                else
                    ctx.Args.Add(part);
            }

            return (name, ctx);
        }
    }
}
