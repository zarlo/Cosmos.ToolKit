using Cosmos.HAL;
using System;

namespace Cosmos.ToolKit.Graphics.Common
{
    
    public class Pixel
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Colour { get; set; }
        public Pixel(int x, int y, int colour)
        {
            X = x;
            Y = y;
            Colour = colour;
        }

    }

    public class Colour
    {
        public int R { get; private set; }
        public int G { get; private set; }
        public int B { get; private set; }
        public int A { get; private set; }


        public Colour(int r, int g, int b, int a)
        {
            R = r;
            G = g;
            B = b;
            A = a;

            if (r > 255 && r < 0)
            {
                R = 0;
            }
            if (g > 255 && g < 0)
            {
                G = 0;
            }
            if (b > 255 && b < 0)
            {
                B = 0;
            }
            if (a > 255 && a < 0)
            {
                A = 0;
            }
        }
        public uint GetUint()
        {
                 
            return (uint)((A << 24) | (R << 16) |
                          (G << 8) | (B << 0));
        }

    }

    

    public class Colours
    {
        public readonly static Colour Red = new Colour(255, 0, 0, 255);
        public readonly static Colour Green = new Colour(0, 255, 0, 255);
        public readonly static Colour Blue = new Colour(0, 0, 255, 255);
        public readonly static Colour Black = new Colour(255, 255, 255, 255);
        public readonly static Colour White = new Colour(0, 0, 0, 255);

        public static Colour GetColour(string HEX)
        {
            Convert.ToInt32(HEX, 16);
            return GetColour(1,1,1);
        }

        public static Colour GetColour(int r, int g, int b)
        {
            return GetColour(r, g, b, 255);
        }

        public static Colour GetColour(int r, int g, int b, int a)
        {
            return new Colour(r, g, b, a);
        }
    }

}
