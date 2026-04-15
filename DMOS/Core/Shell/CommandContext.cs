using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DMOS.Core.Shell
{
    /// <summary>
    /// Represents a command's context.
    /// </summary>
    public class CommandContext
    {
        /// <summary>
        /// What the user actually typed.
        /// </summary>
        public string? Input { get; set; }

        /// <summary>
        /// The dictionary of arguments.
        /// </summary>
        public List<string> Args { get; set; } = [];

        /// <summary>
        /// The dictionary of flags.
        /// </summary>
        public Dictionary<string, bool> Flags { get; set; } = [];

        /// <summary>
        /// Tries to get a flag's value.
        /// </summary>
        /// <param name="name">The flag name.</param>
        /// <param name="value">The output value.</param>
        /// <returns>Whether the flag was found.</returns>
        public bool TryGetFlag(string name, out bool value)
        {
            var dictResult = Flags.TryGetValue(name, out var val);
            value = val;
            return dictResult;
        }

        /// <summary>
        /// Tries to get an argument's value, if it exists within bounds.
        /// </summary>
        /// <param name="index">The argument's index.</param>
        /// <param name="value">The output value.</param>
        /// <returns>Whether the index is valid.</returns>
        public bool TryGetArg(int index, out string? value)
        {
            if (index < 0 || index > Args.Count)
            {
                value = string.Empty;
                return false;
            }

            var arg = Args[index];
            value = arg;
            return true;
        }
    }
}
