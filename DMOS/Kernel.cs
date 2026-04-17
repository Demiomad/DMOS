using Cosmos.Kernel.System.Graphics;
using DMOS.Core;
using DMOS.Core.Info;
using DMOS.Core.Logging;
using DMOS.Extensions;
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

            if (OSInfo.Version.Stage != VersionStage.Stable)
                Shared.Logger?.Log(LogLevel.Warning, "You are using a non-stable build of DMOS. Expect bugs.");

            Console.WriteLine($"Welcome to {OSInfo.FullString}!");
            Console.WriteLine();
        }

        protected override void Run()
        {
            Shared.Shell?.Run();
        }
    }
}
