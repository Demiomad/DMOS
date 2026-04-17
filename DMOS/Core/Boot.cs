using DMOS.Core.Shell.DMShell;
using DMOS.Core.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMOS.Core
{
    /// <summary>
    /// Represents the main booting process.
    /// </summary>
    public static class Boot
    {
        /// <summary>
        /// The system's first boot time.
        /// </summary>
        public static DateTime BootTime { get; private set; }

        /// <summary>
        /// Initializes the core functionality (shell, logger, etc.)
        /// </summary>
        public static void InitializeCore()
        {
            BootTime = DateTime.Now;

            Shared.Logger = new Logger();

            Shared.Logger.Log(LogLevel.Information, "Initializing DMShell...");
            Shared.Shell = new DMShell();
        }
    }
}
