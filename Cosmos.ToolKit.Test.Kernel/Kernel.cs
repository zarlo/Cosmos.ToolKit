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
        
        protected override void Run()
        {
            GFX.DrawText(50, 50, i.ToString());            
            GFX.DrawText(0, 20, "abcdefghijklnmopqrstuvwxyz1234567890\n<>.,\"';:[]#//!");
            GFX.Font.renderString(0, 5, "Powered by the C# Open Source ");
            GFX.Font.renderString(0, 10, "Managed Operating System.");
            i++;
            //GFX.Font.stdColour = i;
            GFX.Clear();
            GFX.Tick();

        }

    }
}
