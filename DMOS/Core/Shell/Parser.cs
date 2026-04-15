using System;
using System.Collections.Generic;
using System.Text;

namespace DMOS.Core.Shell
{
    /// <summary>
    /// Represents a parser.
    /// </summary>
    public static class Parser
    {
        /// <summary>
        /// Splits the string by whitespace, while respecting quoted groups.
        /// </summary>
        /// <param name="input">The raw input.</param>
        /// <returns>The parsed array.</returns>
        public static string[] SplitQuotes(string input)
        {
            var insideQuote = false;
            var current = new StringBuilder();
            var output = new List<string>();

            for (int i = 0; i < input.Length; i++)
            {
                var ch = input[i];

                if (ch == '\'' || ch == '"')
                    insideQuote = !insideQuote;
                else if (char.IsWhiteSpace(ch))
                {
                    if (!insideQuote)
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

        public static (string cmdName, CommandContext ctx) ParseContext(string input)
        {
            const string FlagPrefix = "--";
            
            var ctx = new CommandContext()
            {
                Input = input
            };

            var parts = SplitQuotes(input);
            var name = parts[0];

            // the name isnt important for parsing, we can skip it
            for (int i = 1; i < parts.Length; i++)
            {
                var part = parts[i];

                if (part.StartsWith(FlagPrefix))
                {
                    var flagName = part[FlagPrefix.Length..];
                    ctx.Flags[flagName] = true;
                }
                else
                {
                    ctx.Args.Add(part);
                }
            }

            return (name, ctx);
        }
    }
}
