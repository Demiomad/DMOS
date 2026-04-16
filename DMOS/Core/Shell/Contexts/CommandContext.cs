using System;
using System.Collections.Generic;
using System.Text;

namespace DMOS.Core.Shell.Contexts
{
    /// <summary>
    /// Represents a command's context.
    /// </summary>
    public class CommandContext
    {
        /// <summary>
        /// The list of positional arguments.
        /// </summary>
        public List<string> Args { get; private set; } = [];

        /// <summary>
        /// The list of flags.
        /// </summary>
        public Dictionary<string, bool> Flags { get; private set; } = [];

        /// <summary>
        /// Tries to get an argument.
        /// </summary>
        /// <param name="index">The argument index.</param>
        /// <param name="value">The argument's value.</param>
        /// <returns>Whether the index is valid and the argument is not null/empty.</returns>
        public bool TryGetArg(int index, out string? value)
        {
            if (index < 0 || index >= Args.Count)
            {
                value = string.Empty;
                return false;
            }

            var arg = Args[index];
            value = arg;
            return !string.IsNullOrEmpty(arg);
        }

        /// <summary>
        /// Tries to get a flag.
        /// </summary>
        /// <param name="name">The flag name.</param>
        /// <param name="value">The flag's value.</param>
        /// <returns>Whether the flag was found.</returns>
        public bool TryGetFlag(string name, out bool value)
        {
            if (!Flags.TryGetValue(name, out var flagVal))
            {
                value = false;
                return false;
            }

            value = flagVal;
            return true;
        }
    }
}
