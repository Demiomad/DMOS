using System;
using System.Collections.Generic;
using System.Text;

namespace DMOS.Core.Shell
{
    public static class Shell
    {
        public static void Init()
        {
            // TODO: Implement commands
        }

        public static void Run()
        {
            Console.Write("> ");
            var input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input)) return;
            Console.WriteLine($"Input: {input}");
        }
    }
}
