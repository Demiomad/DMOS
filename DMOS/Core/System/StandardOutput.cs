using Cosmos.Kernel.System.Graphics;
using DMOS.Core.System.Formatting;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMOS.Core.System
{
    /// <summary>
    /// Represents the standard output system.
    /// </summary>
    public class StandardOutput
    {
        private List<string> _buff = [];

        /// <summary>
        /// The console to write the output to.
        /// </summary>
        public KernelConsole? Console { get; set; }

        /// <summary>
        /// Initializes the standard output system.
        /// </summary>
        public StandardOutput()
        {
            Console = KernelConsole.Default;
        }

        /// <summary>
        /// Adds a new entry to the buffer.
        /// </summary>
        /// <param name="format">The string format.</param>
        /// <param name="args">The optional arguments.</param>
        public void Print(string? format, params object?[] args)
        {
            if (string.IsNullOrEmpty(format))
                return;

            _buff.Add(StringFormatter.Format(format, args));
        }

        /// <summary>
        /// Clears the buffer and the output.
        /// </summary>
        public void Clear()
        {
            _buff.Clear();
            Console?.Clear();
        }

        /// <summary>
        /// Pushes the buffer to the output.
        /// </summary>
        public void Flush()
        {
            foreach (var item in _buff)
            {
                foreach (var ch in item)
                {
                    if (ch == '\b')
                        Console?.CursorX = (int)(Console?.CursorX - 1)!;
                    else if (ch == '\n')
                    {
                        Console?.CursorY = (int)(Console?.CursorY + 1)!;
                        Console?.CursorX = 0;
                    }
                    else if (ch == '\r')
                        Console?.CursorX = 0;
                    else if (!char.IsControl(ch))
                        Console?.Write(ch);
                }
            }

            _buff.Clear();
        }
    }
}
