using Cosmos.Kernel.System.Graphics;
using Cosmos.Kernel.System.Keyboard;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMOS.Core.System
{
    /// <summary>
    /// Represents the standard output system.
    /// </summary>
    public class StandardInput
    {
        private List<string> _inputHistory = [];

        /// <summary>
        /// Reads a string from the user.
        /// </summary>
        /// <param name="output">The output.</param>
        /// <param name="prompt">The optional prompt.</param>
        /// <returns>The read string.</returns>
        public string Read(StandardOutput output, string? prompt = "")
        {
            if (!string.IsNullOrEmpty(prompt))
            {
                output.Print(prompt);
                output.Flush();
            }

            KeyEvent? key;
            var sb = new StringBuilder();
            var historyIndex = 0;
            var oldX = output.Console?.CursorX;
            var oldY = output.Console?.CursorY;

            do
            {
                if (KeyboardManager.TryReadKey(out key))
                {
                    if (key == null)
                        continue;

                    if (key.Key == ConsoleKeyEx.Backspace &&
                        sb.Length > 0)
                    {
                        sb.Remove(sb.Length - 1, 1);

                        output.Console?.MoveCursorLeft();
                        output.Console?.Write(' ');
                        output.Console?.MoveCursorLeft();
                    }
                    else if (key.Key == ConsoleKeyEx.UpArrow)
                    {
                        if (historyIndex >= _inputHistory.Count)
                            continue;

                        output.Console?.SetCursorPosition((int)oldX!, (int)oldY!);

                        sb = new StringBuilder(_inputHistory[historyIndex]);
                        output.Console?.Write(_inputHistory[historyIndex]);

                        historyIndex++;
                    }
                    else if (key.Key == ConsoleKeyEx.DownArrow)
                    {
                        if (historyIndex <= 0)
                            continue;

                        output.Console?.SetCursorPosition((int)oldX!, (int)oldY!);

                        sb = new StringBuilder(_inputHistory[historyIndex]);
                        output.Console?.Write(_inputHistory[historyIndex]);

                        historyIndex--;
                    }
                    else if (!char.IsControl(key.KeyChar))
                    {
                        sb.Append(key.KeyChar);

                        output.Console?.Write(key.KeyChar.ToString());
                    }
                }
            }
            while (key?.Key != ConsoleKeyEx.Enter);
            output.Console?.WriteLine();

            return sb.ToString();
        }
    }
}
