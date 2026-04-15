using DMOS.Core.Shell.Commands;
using DMOS.Core.Shell.Parsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMOS.Core.Shell
{
    public static class Shell
    {
        public static void Init()
        {
            Registry.Register(new EchoCmd());
        }

        public static void Run()
        {
            Console.Write("> ");
            var input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input)) return;

            try
            {
                var cmd = Parser.Parse(input);
                var result = cmd?.Run();
                cmd?.Args.ForEach((arg) => arg.SetDefaultValue());

                if (!result!.IsSuccess)
                    Console.WriteLine(result.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
