using System;
using System.Collections.Generic;
using System.Text;

namespace DMOS.Core.Shell.Arguments
{
    public class PositionalArgument : CommandArgument
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Position { get; set; }
        public bool Required { get; set; }
    }
}
