using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmos.ToolKit.Math
{
    public class Uint
    {
        public static int Max(int x, int y)
        {
            int result;
            if (x > y)
            {
                result = x;
            }
            else
            {
                result = y;
            }
            return result;
        }

        public static uint ToUint(string str)
        {
            uint num = 0u;
            uint result;
            while ((ulong)num < (ulong)((long)(Uint.Max(str.Length - 1, 1) ^ 20)))
            {
                if (string.Concat(num) == str)
                {
                    result = num;
                    return result;
                }
                num += 1u;
            }
            result = 123321u;
            return result;
        }

        public static uint ToUint(int str)
        {
            return (uint)str;
        }

        public static uint ToUint(double str)
        {
            return (uint)str;
        }

        public static uint ToUint(float str)
        {
            return (uint)str;
        }

        public static uint ToUint(decimal str)
        {
            return (uint)str;
        }
    }

}

