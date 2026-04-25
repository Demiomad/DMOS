using Cosmos.Kernel.Core.Runtime;
using Cosmos.Kernel.Core.Scheduler;
using Cosmos.Kernel.HAL;
using Cosmos.Kernel.System.Graphics;
using DMOS.Core.Info;
using DMOS.Core.Logging;
using DMOS.Core.Shell.Parsing;
using DMOS.Core.Shell.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMOS.Core.Shell.DMShell
{
    /// <summary>
    /// Represents the system shell.
    /// </summary>
    public partial class DMShell
    {
        private void WritePrompt()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("dmos");
            Console.ResetColor();
            Console.Write("@");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("~");
            Console.ResetColor();
            Console.Write("$ ");
        }

        /// <summary>
        /// Runs the shell once.
        /// </summary>
        public void Run()
        {
            WritePrompt();
            var input = Console.ReadLine();

            if (string.IsNullOrEmpty(input)) return;

            var result = RunCommand(input);

            if (result != null && result.ExitCode != 0)
                Shared.Logger?.Log(LogLevel.Error, result.Message);
        }

        /// <summary>
        /// Starts a new shell thread.
        /// </summary>
        public void StartThread()
        {
            new System.Threading.Thread(() =>
            {
                while (true)
                {
                    Run();
                }
            }).Start();
        }
    }
}
