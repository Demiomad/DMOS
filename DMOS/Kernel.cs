using Cosmos.Kernel.System.Graphics;
using DMOS.Core;
using DMOS.Core.Info;
using DMOS.Core.Logging;
using System.Drawing;
using DMOS.Extensions;
using Sys = Cosmos.Kernel.System;
using Cosmos.Kernel.System.Mouse;
using DMOS.Core.Shell.DMShell;

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

            Shared.Shell?.StartThread();
        }

        protected override void Run()
        {
            var font = KernelConsole.Default?.Font;
            var canvas = KernelConsole.Default?.Canvas;
            var width = canvas!.Width;
            var now = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            var x = width - (now.Length * font!.Width);

            canvas.DrawFilledRectangle(Color.Black, x - 10, 10, width, 20);
            canvas.DrawString(now, font, Color.White, x - 10, 10);
            canvas.Display();
        }
    }
}
