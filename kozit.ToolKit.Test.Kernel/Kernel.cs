using System;

using Sys = Cosmos.System;

namespace kozit.ToolKit.Test.Kernel
{
    public class Kernel : Sys.Kernel
    {
        kozit.ToolKit.Graphics.GFXManger GFX;
        protected override void BeforeRun()
        {
            Console.WriteLine("Cosmos booted successfully.");

            GFX = new Graphics.GFXManger(Graphics.GFXType.VGA);
            
            GFX.Clear();
            
        }
        int i = 0;
        protected override void Run()
        {
            GFX.DrawText(0, 10, GFX.Colors().ToString());
            GFX.DrawText(0, 25, "abcdefghijklnmopqrstuvwxyz1234567890\n<>.,\"';:[]#//!");
            GFX.DrawText(0, 40, "Cosmos.ToolKit !!test!!");
            GFX.DrawText(0, 50, Console.ReadLine());
            GFX.DrawText(50,10, GFX.Buffer.Count.ToString());
            
            
            //GFX.Clear();
            GFX.Tick();

        }

    }
}
