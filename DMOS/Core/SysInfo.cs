using System;
using System.Collections.Generic;
using System.Text;

namespace DMOS.Core
{
    public static class SysInfo
    {
        public static string OSVersion { get; } = "0.1.0-alpha";
        public static string OSName { get; } = "DMOS";
        public static string OSString { get; } = $"{OSName} v{OSVersion}";
    }
}
