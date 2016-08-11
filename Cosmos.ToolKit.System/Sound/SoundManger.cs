using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmos.ToolKit.System.Sound
{
    public class SoundManger
    {
        static Cosmos.HAL.PCSpeaker Speaker = new HAL.PCSpeaker();
        public static void playSound(int Hz)
        {

            Speaker.playSound((uint)Hz);

        }

    }
}
