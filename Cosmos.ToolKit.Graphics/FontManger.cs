
namespace Cosmos.ToolKit.Graphics
{
    public abstract class Font
    {
        
        public abstract int fontSize();

        public abstract int[] getChar(char c);
    }
    

    public class FontManger
    {

        public int stdColour { get; set; }

        public Font font { get; set; }

        private GFXManger gfx;

        public FontManger(GFXManger GFX)
        {
            stdColour = 1;
            font = new Fonts.BasicFont();
            gfx = GFX;
        }

        public void renderChar(int x, int y, char c)
        {
            renderChar(x, y, c, stdColour);
        }

        public void renderString(int x, int y, string text, int gap = 2)
        {
            renderString(x, y, text, stdColour, gap);
        }

        public void renderChar(int x, int y, char c, int color)
        {
            
            int[] charArray = font.getChar(c);
            for (int i = 0; i < font.fontSize(); i++)
            {
                for (int j = 0; j < font.fontSize(); j++)
                {
                    if (charArray[(i * font.fontSize()) + j] == 1)
                    {
                        gfx.SetPixel(x + j, y + i, color);
                    }
                }
            }
        }

        public void renderString(int x, int y, string text, int color, int gap = 2, int nlgap = 2)
        {
            
            int wx = x;
            int wy = y;
            char[] t = text.ToCharArray();
            for (int i = 0; i < t.Length; i++)
            {
                if (t[i] == '\n')
                {
                    wy += font.fontSize() + nlgap;
                    wx = x;
                }
                renderChar(wx, wy, t[i], color);
                wx += gap + font.fontSize();
            }
        }


    }
}
