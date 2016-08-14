namespace Cosmos.ToolKit.Math.Graphics
{
    public static class Shapes
    {

        public static byte[] Box(byte[] GBuffer, int x, int y, int width, int height, int colour)
        {

            for (int yy = y; yy < y + height; yy++)
            {

                for (int xx = x; xx < x + width; xx++)
                {
                    GBuffer[xx + (yy * 320)] = (byte)colour;
                }

            }

            return GBuffer;
        }

        public static byte[] Triangle(byte[] GBuffer, int x, int y, int width, int height, int colour)
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

                    GBuffer[xx + (yy * 320)] = (byte)colour;
                    xx++;

                }
                xx = xx + blank;
                blank = blank - 2;
                blankset = blankset + 2;
                yy++;
            }

            return GBuffer;
        }

        public static byte[] RTriangle(byte[] GBuffer, int x, int y, int width, int height, int colour)
        {
            return RTriangle(GBuffer, x, y, width, height, colour, true);
        }

        public static byte[] RTriangle(byte[] GBuffer, int x, int y, int width, int height, int colour, bool isleft)
        {
            int xx = 1;
            int yy = y;

            while (yy <= y + height)
            {
                if (!isleft)
                    xx = xx + 1;
                int _x = 0;
                while (_x <= xx)
                {

                    GBuffer[xx + (yy * 320)] = (byte)colour;
                    _x++;
                }
                if (isleft)
                    xx = xx + 1;
                yy++;
            }

            return GBuffer;
        }

    }

}