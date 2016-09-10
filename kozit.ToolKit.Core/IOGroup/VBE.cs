using Cosmos.Core;

namespace kozit.ToolKit.Core.IOGroup
{
    public class VBE : Cosmos.Core.IOGroup.IOGroup
    {
        public IOPort VbeIndex = new IOPort(0x01CE);
        public IOPort VbeData = new IOPort(0x01CF);

        public MemoryBlock VBEMemoryBlock = new MemoryBlock(0xE0000000, 1280 * 1024 * 4);
    }
}
