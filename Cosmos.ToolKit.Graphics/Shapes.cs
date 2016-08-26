﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmos.ToolKit.Graphics
{
    public class Shapes
    {

        public static void Box(List<Common.Pixel> GBuffer, int x, int y, int width, int height, int colour)
        {

            for (int yy = y; yy < y + height; yy++)
            {

                for (int xx = x; xx < x + width; xx++)
                {
                    GBuffer.Add(new Common.Pixel( xx ,yy,colour));
                }

            }

           
        }

        public static void Triangle(List<Common.Pixel> GBuffer, int x, int y, int width, int height, int colour)
        {

            int xx = x;
            int yy = y;
            int blank = (width % 2) - 1;
            int blankset = 1;

            while (yy <= y + height)
            {
                xx = xx + blank;
                while (xx <= blankset + width)
                {

                    GBuffer.Add(new Common.Pixel(xx, yy, colour));
                    xx++;

                }
                xx = xx + blank;
                blank = blank - 2;
                blankset = blankset + 2;
                yy++;
            }
            
        }

    }
}
