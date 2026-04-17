using DMOS.Core.Logging;
using DMOS.Core.Shell.DMShell;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMOS.Core
{
    /// <summary>
    /// Global values.
    /// </summary>
    public static class Shared
    {
        /// <summary>
        /// The system shell.
        /// </summary>
        public static DMShell? Shell { get; set; }

        /// <summary>
        /// The logger.
        /// </summary>
        public static Logger? Logger { get; set; }
    }
}
