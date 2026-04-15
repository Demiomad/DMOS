using DMOS.Core.Shell.Arguments;
using DMOS.Core.Shell.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMOS.Core.Shell.Parsing
{
    public static class Parser
    {
        private const string ShortOptPrefix = "-";
        private const string OptPrefix = "--";

        private static string[] ParseQuotes(string input)
        {
            var result = new List<string>();
            var inQuotes = false;
            var current = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                var ch = input[i];

                if (ch == '"' || ch == '\'')
                    inQuotes = !inQuotes;
                else if (char.IsWhiteSpace(ch))
                {
                    if (!inQuotes)
                    {
                        result.Add(current.ToString());
                        current.Clear();
                    }
                    else
                        current.Append(ch);
                }
                else
                    current.Append(ch);
            }

            result.Add(current.ToString());
            return result.ToArray();
        }

        private static void SetOptValue(Command cmd, string part, string prefix, bool isShort)
        {
            var name = part.Substring(prefix.Length);

            var opt = cmd.Args.OfType<OptionArgument>().FirstOrDefault(opt =>
            {
                if (isShort)
                    return opt.ShortName == name;
                return opt.Name == name;
            });

            if (opt == null)
                return;

            opt.Value = true;
        }

        public static Command? Parse(string input)
        {
            var parts = ParseQuotes(input);

            if (parts.Length == 0)
                return null;

            var name = parts[0];
            var cmd = Registry.Get(name);

            if (cmd == null)
                throw new Exception($"Command not found: {name}");

            if (parts.Length == 1)
                return cmd;

            var posIndex = 0;

            for (int i = 1; i < parts.Length; i++)
            {
                var part = parts[i];

                if (part.StartsWith(ShortOptPrefix))
                    SetOptValue(cmd, part, ShortOptPrefix, true);
                else if (part.StartsWith(OptPrefix))
                    SetOptValue(cmd, part, OptPrefix, false);
                else
                {
                    var arg = cmd.Args.OfType<PositionalArgument>().FirstOrDefault(pos => pos.Position == posIndex);

                    if (arg == null)
                        continue;

                    arg.Value = part;
                }
            }

            return cmd;
        }
    }
}
