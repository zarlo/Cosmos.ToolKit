using System;

using Sys = Cosmos.System;

namespace Cosmos.ToolKit.Test.Kernel
{
    public class Kernel : Sys.Kernel
    {
        Cosmos.ToolKit.Graphics.GFXManger GFX;
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
            GFX.DrawText(0, 40, "cosmos.toolkit !!test!!");
            GFX.DrawText(0, 50, Console.ReadLine());

            
            
            //GFX.Clear();
            GFX.Tick();

        }

    }
}
