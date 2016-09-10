using Cosmos.HAL;
using System;

namespace kozit.ToolKit.Graphics.Common
{
    
    public class Pixel
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Color { get; set; }
        public Pixel(int x, int y, int Color)
        {
            X = x;
            Y = y;
            Color = Color;
        }

    }

    public class Color
    {
        public int R { get; private set; }
        public int G { get; private set; }
        public int B { get; private set; }
        public int A { get; private set; }


        public Color(int r, int g, int b, int a)
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

    

    public class Colors
    {
        public readonly static Color Red = new Color(255, 0, 0, 255);
        public readonly static Color Green = new Color(0, 255, 0, 255);
        public readonly static Color Blue = new Color(0, 0, 255, 255);
        public readonly static Color Black = new Color(255, 255, 255, 255);
        public readonly static Color White = new Color(0, 0, 0, 255);

        public static Color GetColor(string HEX)
        {
            Convert.ToInt32(HEX, 16);
            return GetColor(1,1,1);
        }

        public static Color GetColor(int r, int g, int b)
        {
            return GetColor(r, g, b, 255);
        }

        public static Color GetColor(int r, int g, int b, int a)
        {
            return new Color(r, g, b, a);
        }
    }

}
