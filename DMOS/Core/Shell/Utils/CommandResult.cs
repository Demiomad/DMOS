using System;
using System.Collections.Generic;
using System.Text;

namespace DMOS.Core.Shell.Utils
{
    public class CommandResult
    {
        public int ExitCode { get; set; }
        public string? Message { get; set; }
        public bool IsSuccess => ExitCode == 0;
    }
}
