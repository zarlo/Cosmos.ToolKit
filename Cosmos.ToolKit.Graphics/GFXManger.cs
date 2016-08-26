using Cosmos.HAL.Drivers;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Cosmos.ToolKit.Graphics
{


    public enum GFXType
    {
        VBE,
        VGA,
        Null
    }

    public enum ScreenSize
    {
        Size320x200x8,
        Size320x200x4,
        Size320x200x2
    }

    public class GFXManger
    {

        private HAL.VGAScreen m_VGA;
        private VBEDriver m_VBE;

        public GFXType Type { get; private set; }
        public int width { get; private set; }
        public int height { get; private set; }

        public FontManger Font { get; set; }

        public bool Buffered { get; set; }
        public List<Common.Pixel> Buffer = new List<Common.Pixel>();
        

        public int Colors()
        {
            if (Type == GFXType.VGA) {
                return m_VGA.Colors;
            }
            return 2^32;
        }



        public GFXManger(GFXType type)
        {
            if (GFXType.VGA == type)
            {
                //setup the VGA driver
                Type = GFXType.VGA;
                m_VGA = new HAL.VGAScreen();
                m_VGA.SetGraphicsMode(HAL.VGAScreen.ScreenSize.Size320x200, HAL.VGAScreen.ColorDepth.BitDepth8);
                //set width and height
                width = m_VGA.PixelWidth;
                height = m_VGA.PixelHeight;
            }
            else
            {
                //setup the VBE driver
                Type = GFXType.VBE;
                m_VBE = new VBEDriver();
                m_VBE.vbe_set(320, 200, 8);
                //set width and height
                width = 200;
                height = 320;
            }
            Common();
        }

        private void Common()
        {
            this.Buffered = true;
            Font = new FontManger(this);
            
            
        }

        public void Tick()
        {
            if (Buffered)
            {
                this.Clear();
                foreach (Common.Pixel Item in Buffer)
                {

                    RealSetPixel(Item.X,Item.Y,Item.Colour);

                }

                Buffer = new List<Graphics.Common.Pixel>();

                //if (Bufferold != Buffer)
                //{
                //this.Clear();

                //for (int y = 0; y < height; y++)
                //{
                //for (int x = 0; x < width; x++)
                //{
                //RealSetPixel(x, y, Buffer[x + (y * 320)]);
                //if (x + (y * 320) == setto)
                //{
                //    Bufferold = Buffer;
                //    Buffer = new byte[320 * 200];
                //    setto = 0;
                //    break;
                //}
                //}
                //}
                // }
                //Buffer = new byte[320 * 200];

            }
        }
        public void Clear()
        {
            for (int y = 0; y <= height - 1; y++)
            {
                for (int x = 0; x <= width - 1; x++)
                {
                    RealSetPixel(x, y, 0);
                }
            }
            
        }

        private void RealSetPixel(int x, int y, int c)
        {
            if (Type == GFXType.VGA)
            {
                m_VGA.SetPixel320x200x8((uint)x, (uint)y, (uint)c);
            }
            if (Type == GFXType.VBE)
            {
                m_VBE.set_vram((uint)x + (uint)y * 320, (byte)c);
            }
        }

        public void SetPixel(int x, int y, int c)
        {
            if (Buffered)
            {
                Buffer.Add(new Common.Pixel( x , y,c));
               
            }
            else
            {
                RealSetPixel(x, y, c);
            }
        }

        public void SetPaletteFromFile(string File)
        {

        }

        public void SetPalette(int Index, byte[] Palette)
        {
            if (Type == GFXType.VGA)
            {
                m_VGA.SetPalette(Index, Palette);
            }
        }

        public void SetPaletteEntry(int Index, byte R, byte G, byte B)
        {
            if (Type == GFXType.VGA)
            {
                m_VGA.SetPaletteEntry(Index, R, G, B);
            }
        }

        public void DrawText(int x, int y, string Text, string FontName = "BasicFont")
        {

            Font.renderString(x, y, Text,FontName);

        }

    }
}