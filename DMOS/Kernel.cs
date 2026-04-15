using Cosmos.Kernel.System.Graphics;
using DMOS.Core;
using DMOS.Core.Logging;
using DMOS.Core.Shell;
using DMOS.Extensions;
using System;
using System.Runtime;
using System.Runtime.CompilerServices;
using Sys = Cosmos.Kernel.System;

namespace DMOS
{
    /// <summary>
    /// Main kernel class - inherits from Cosmos.Kernel.System.Kernel.
    /// </summary>
    public class Kernel : Sys.Kernel
    {
        public static Logger Logger { get; set; } = new() { Context = SysInfo.OSName };
        private static Shell _sh = new();

        protected override void BeforeRun()
        {
            KernelConsole.Default?.SetFontFromResource("DMOS.Resources.Fonts.font.psf");
            Logger.Log(LogLevel.Info, $"Welcome to {SysInfo.OSString}!");
        }

        protected override void Run()
        {
            _sh.Run();
        }
    }
}
