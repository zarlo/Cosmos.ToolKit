using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmos.ToolKit.Common.File.Encode
{
    public class Content
    {
        List<File> Files = new List<File>();
        public Content()
        { }

        public Content(byte[] DataStream)
        {



        }

        public byte[] GetDataStream()
        {

            List<byte> dataStream = new List<byte>();

           dataStream.AddRange(BitConverter.GetBytes(Files.Count - 1));

            for (int i = 0; i < Files.Count; i++)
            {
                dataStream.AddRange(BitConverter.GetBytes(Files[i].GetDataStream().Length));
                dataStream.AddRange(Files[i].GetDataStream());
            }

            return dataStream.ToArray();

        }

        public void AddContent(string path, string Name)
        { 
            Files.Add(new File(path,Name));
        }

    }
}
