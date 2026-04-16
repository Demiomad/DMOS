using DMOS.Core.Shell;
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
        /// Initializes the core functionality (shell, logger, etc.)
        /// </summary>
        public static void InitializeCore()
        {
            Shared.Shell = new DMShell();
        }
    }
}
