namespace Cosmos.ToolKit.Math.Graphics
{
    public static class Shapes
    {



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