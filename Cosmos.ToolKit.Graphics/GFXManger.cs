using Cosmos.HAL.Drivers;
namespace Cosmos.ToolKit.Graphics
{
    public enum GFXType
    {
        VGE,
        VGA,
        Null
    }
    public class GFXManger
    {
        public GFXType Type { get; private set; }
        private HAL.VGAScreen m_VGA;
        private VBEDriver m_VBE;

        public int width { get; private set; }
        public int height { get; private set; }

        public FontManger Font { get; set; }

        public bool Buffered { get; set; }
        public byte[] Buffer = new byte[320*200];

        private int setto;

        public GFXManger(GFXType type)
        {
            if (GFXType.VGA == type)
            {
                m_VGA = new HAL.VGAScreen();
                m_VGA.SetGraphicsMode(HAL.VGAScreen.ScreenSize.Size320x200, HAL.VGAScreen.ColorDepth.BitDepth8);
                Type = GFXType.VGA;


                width = m_VGA.PixelWidth;

                height = m_VGA.PixelHeight;
            }
            else
            {
                Type = GFXType.VGE;
                m_VBE = new VBEDriver();
                m_VBE.vbe_set(320, 200, 8);
                width = 200;
                height = 320;
            }
            Common();
        }

        public GFXManger(HAL.VGAScreen VGA)
        {
            m_VGA = VGA;
            m_VGA.SetGraphicsMode(HAL.VGAScreen.ScreenSize.Size320x200, HAL.VGAScreen.ColorDepth.BitDepth8);
            Type = GFXType.VGA;
            

            width = m_VGA.PixelWidth;

            height = m_VGA.PixelHeight;
            Common();
        }

        public GFXManger(VBEDriver VBE)
        {
            Type = GFXType.VGE;
            m_VBE = VBE;
            m_VBE.vbe_set(320,200,8);
            width = 200;
            height = 320;
            Common();
        }

        private void Common()
        {

            Font = new FontManger(this);

        }

        public void Tick()
        {
            if (Buffered)
            {
                for (int y = 0; y <= height - 1; y++)
                {
                    for (int x = 0; x <= width - 1; x++)
                    {
                        RealSetPixel(x, y, Buffer[x + (y * 320)]);
                        if (x + (y * 320) == setto)
                        {
                            Buffer = new byte[320 * 200];
                            setto = 0;
                            break;
                        }
                    }
                }
                Buffer = new byte[320 * 200];
            }
        }
        public void Clear()
        {
            for (int y = 0; y <= height - 1; y++)
            {
                for (int x = 0; x <= width - 1 ; x++)
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
            if (Type == GFXType.VGE)
            {
                m_VBE.set_vram((uint)x + (uint)y * 320, (byte)c);
            }
        }

        public void SetPixel(int x, int y, int c)
        {
            if (Buffered)
            {
                Buffer[x + (y * 320)] = (byte)c;
                if (x + (y * 320) > setto)
                    setto = x + (y * 320);

            }
            else
            {
                RealSetPixel(x,y,c);
            }
        }

        public void DrawText(int x, int y, string Text)
        {

            Font.renderString(x, y, Text);

        }

    }
}
