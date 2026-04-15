using DMOS.Core.Shell.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMOS.Core.Shell
{
    public static class Registry
    {
        public static List<Command> Commands { get; private set; } = [];

        public static void Register(Command cmd)
            => Commands.Add(cmd);

        public static Command? Get(string name)
            => Commands.FirstOrDefault(c => c.Name == name);
    }
}
