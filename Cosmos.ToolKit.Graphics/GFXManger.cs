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

        public bool Buffered { get; set; }
        public byte[] Buffer = new byte[320*200];

        public GFXManger(HAL.VGAScreen VGA)
        {
            m_VGA.SetGraphicsMode(HAL.VGAScreen.ScreenSize.Size320x200, HAL.VGAScreen.ColorDepth.BitDepth8);
            Type = GFXType.VGA;
            m_VGA = VGA;

            width = m_VGA.PixelWidth;

            height = m_VGA.PixelHeight;
        }

        public GFXManger(VBEDriver VBE)
        {
            Type = GFXType.VGE;
            m_VBE = VBE;
            m_VBE.vbe_set(320,200,8);
            width = 200;
            height = 320;
        }
        public void Tick()
        {
            if (Buffered)
            {

            }
        }
        public void Clear()
        {
            for (int y = 0; y <= 320; y++)
            {
                for (int x = 0; x <= 320; x++)
                {
                    SetPixel(x, y, 0);
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
            }
            else
            {
                RealSetPixel(x,y,c);
            }
        }

        public void DrawPNG(int x, int y, string Path)
        {

        }

    }
}
