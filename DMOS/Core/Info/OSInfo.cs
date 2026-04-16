using System;
using System.Collections.Generic;
using System.Text;

namespace DMOS.Core.Info
{
    /// <summary>
    /// Represents the system information.
    /// </summary>
    public static class OSInfo
    {
        /// <summary>
        /// The OS name.
        /// </summary>
        public static string Name { get; } = "DMOS";

        /// <summary>
        /// The version of this OS.
        /// </summary>
        public static OSVersion Version { get; } = new(0, 1, 0, VersionStage.PreAlpha);

        /// <summary>
        /// Represents the OS string.
        /// </summary>
        public static string FullString { get; } = $"{Name} v{Version.ToVersionString()}";
    }
}
