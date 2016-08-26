
using System.Collections.Generic;

namespace Cosmos.ToolKit.Graphics
{
    public interface Font
    {
        
        int fontSize();
        string Name { get;}
        int[] getChar(char c);

    }
    

    public class FontManger
    {

        public int stdColour { get; set; }

        public List<Font> font = new List<Font>();

        private GFXManger gfx;

        public FontManger(GFXManger GFX)
        {
            stdColour = 1;
            font.Add( new Fonts.BasicFont());
            gfx = GFX;
        }

        public Font GetFont(string Name)
        {

            foreach (Font Item in font)
            {

                if (Item.Name == Name)
                    return Item;

            }
            return font[0];

        }

        public void renderChar(int x, int y, char c, string FontName = "BasicFont")
        {
            renderChar(x, y, c, stdColour, FontName);
        }

        public void renderString(int x, int y, string text, string FontName = "BasicFont")
        {
            renderString(x, y, text, stdColour, FontName);
        }

        public void renderChar(int x, int y, char c, int colour, string FontName = "BasicFont")
        {
            Font temp = GetFont(FontName);
            int[] charArray = temp.getChar(c);
            for (int i = 0; i < temp.fontSize(); i++)
            {
                for (int j = 0; j < temp.fontSize(); j++)
                {
                    if (charArray[(i * temp.fontSize()) + j] == 1)
                    {
                        gfx.SetPixel(x + j, y + i, colour);
                    }
                }
            }
        }

        public void renderString(int x, int y, string text, int colour, string FontName = "BasicFont")
        {
            Font temp = GetFont(FontName);
            int wx = x;
            int wy = y;
            char[] t = text.ToCharArray();
            for (int i = 0; i < t.Length; i++)
            {
                if (t[i] == '\n')
                {
                    wy += temp.fontSize() + 2;
                    wx = x;
                }
                renderChar(wx, wy, t[i], colour);
                wx += 2 + temp.fontSize();
            }
        }


    }
}
