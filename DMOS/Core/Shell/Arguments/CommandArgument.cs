using System;
using System.Collections.Generic;
using System.Text;

namespace DMOS.Core.Shell.Arguments
{
    public class CommandArgument
    {
        public object? Value { get; set; }

        public virtual void SetDefaultValue()
            => Value = null;
    }
}
