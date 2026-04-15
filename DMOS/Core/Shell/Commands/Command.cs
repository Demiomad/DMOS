using DMOS.Core.Shell.Arguments;
using DMOS.Core.Shell.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMOS.Core.Shell.Commands
{
    public abstract class Command
    {
        public abstract List<CommandArgument> Args { get; }
        public abstract string Name { get; }
        public abstract string Description { get; }
        public abstract CommandResult Run();

        public PositionalArgument? GetArg(string name)
            => Args.OfType<PositionalArgument>().FirstOrDefault(arg => arg.Name == name);

        public OptionArgument? GetOpt(string name)
            => Args.OfType<OptionArgument>().FirstOrDefault(arg => arg.Name == name);
    }
}
