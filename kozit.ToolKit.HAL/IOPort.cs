using Cosmos.Core;
namespace kozit.ToolKit.HAL
{
    public class IOPorts
    {

        static IOPort io = new IOPort(0);
        static int PP = 0, D = 0;
        public static void Outb(ushort port, byte data)
        {
            if (io.Port != port)
                io = new IOPort(port);
            io.Byte = data;
            PP = port;
            D = data;

        }
        public static byte Inb(ushort port)
        {
            if (io.Port != port)
                io = new IOPort(port);
            return io.Byte;
        }

    }
}
