using DMOS.Core.Shell;
using System;
using System.Runtime;
using System.Runtime.CompilerServices;
using Sys = Cosmos.Kernel.System;

namespace DMOS
{
    /// <summary>
    /// Main kernel class - inherits from Cosmos.Kernel.System.Kernel.
    /// </summary>
    public unsafe class Kernel : Sys.Kernel
    {
        protected override void BeforeRun()
        {
            Shell.Init();
        }

        protected override void Run()
        {
            Shell.Run();
        }
    }
}
