using Cosmos.Kernel.System.Graphics;
using DMOS.Core;
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
        protected override void BeforeRun()
        {
            KernelConsole.Default?.SetFontFromResource("DMOS.Resources.Fonts.font.psf");
            Boot.InitializeCore();
        }

        protected override void Run()
        {
            Shared.Shell.Run();
        }
    }
}
