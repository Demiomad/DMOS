using Cosmos.Kernel.Core.Runtime;
using Cosmos.Kernel.System.Graphics;
using Cosmos.Kernel.System.Graphics.Fonts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMOS.Extensions
{
    public static class KernelConsoleExtensions
    {
        public static void SetFontFromResource(this KernelConsole console, string resourceName)
        {
            if (!resourceName.EndsWith(".psf"))
                return;

            var resourceSpan = ResourceManager.GetResourceAsSpan(resourceName);
            console.Font = PCScreenFont.LoadFont(resourceSpan.ToArray());
        }
    }
}
