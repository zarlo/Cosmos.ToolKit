using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

namespace Cosmos.ToolKit.Test.Kernel
{
    public class Kernel : Sys.Kernel
    {
        protected override void BeforeRun()
        {
            Console.WriteLine("Cosmos booted successfully.");
        }

        protected override void Run()
        {

        }
    }
}
