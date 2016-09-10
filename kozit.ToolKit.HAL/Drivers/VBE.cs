using Cosmos.Debug.Kernel;

namespace kozit.ToolKit.HAL.Drivers
{
    public class VBE
    {

        internal Debugger mDebugger = new Debugger("kozit.HAL", "VBE");
        private Core.IOGroup.VBE IO = new Core.IOGroup.VBE();

        public int Width { get; private set; }
        public int Height { get; private set; }

        private void vbe_write(ushort index, ushort value)
        {
            IO.VbeIndex.Word = index;
            IO.VbeData.Word = value;
        }

        public void vbe_set(ushort xres, ushort yres, ushort bpp)
        {
            Width = xres;
            Height = yres;
            //Disable Display
            vbe_write(0x4, 0x00);
            //Set Display Xres
            vbe_write(0x1, xres);
            //SetDisplay Yres
            vbe_write(0x2, yres);
            //SetDisplay bpp
            vbe_write(0x3, bpp);
            //Enable Display and LFB           
            vbe_write(0x4, (ushort)(0x01 | 0x40));
        }

        public void set_vram(int x, int y, byte value)
        {
            set_vram((uint)(x + (y * Width)), value);
        }

        public void set_vram(uint index, byte value)
        {
            IO.VBEMemoryBlock[index] = value;
        }

        public byte get_vram(int x, int y)
        {
            return get_vram((uint)(x + ( y * Width)));
        }

        public byte get_vram(uint index)
        {
            return (byte)IO.VBEMemoryBlock[index];
        }

    }
}