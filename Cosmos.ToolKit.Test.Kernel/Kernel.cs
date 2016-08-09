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
            GFX.Buffered = true;
            GFX.Clear();
            GFX.Font.font = new Graphics.Fonts.BasicFont();
            
        }
        int i = 0;
        string text = @"Powered by the C# Open Source \n Managed Operating System.";
        protected override void Run()
        {
            GFX.DrawText(50, 50, i.ToString());            
            GFX.DrawText(0, 20, "abcdefghijklnmopqrstuvwxyz1234567890\n<>.,\"';:[]#//!");
            GFX.Font.renderString(0, 35, text);
            i++;
            //GFX.Font.stdColour = i;
            GFX.Clear();
            GFX.Tick();

        }

    }
}
