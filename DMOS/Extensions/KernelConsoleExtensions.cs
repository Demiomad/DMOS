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
        /// <summary>
        /// Sets a font from an embedded resource.
        /// </summary>
        /// <param name="console">The <see cref="KernelConsole"/> object.</param>
        /// <param name="resourceName">The embedded resource's name.</param>
        public static void SetFontFromResource(this KernelConsole console, string resourceName)
        {
            if (!resourceName.EndsWith(".psf"))
                return;

            var resourceSpan = ResourceManager.GetResourceAsSpan(resourceName);
            console.Font = PCScreenFont.LoadFont(resourceSpan.ToArray());
        }
    }
}
