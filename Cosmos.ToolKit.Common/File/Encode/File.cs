using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Cosmos.ToolKit.Common.File.Encode
{
   public class File
    {

        public string Content { get; private set; }
        public string Name { get; private set; }

        public File(string Path, string Name)
        {
            this.Name = Name;         
            this.Content = System.IO.File.ReadAllText(Path);
        }

        public File(byte[] DataStream)
        {

            int nameLength = BitConverter.ToInt32(DataStream, 0);

            int contentLength = BitConverter.ToInt32(DataStream, 4);

            this.Name = Encoding.UTF8.GetString(DataStream,8,nameLength);
            this.Content = Encoding.UTF8.GetString(DataStream, 8 + nameLength, contentLength);

        }

        public byte[] GetDataStream()
        {

            List<byte> dataStream = new List<byte>();

            dataStream.AddRange(BitConverter.GetBytes(this.Name.Length));
            dataStream.AddRange(BitConverter.GetBytes(this.Content.Length));
            dataStream.AddRange(Encoding.UTF8.GetBytes(this.Name));
            dataStream.AddRange(Encoding.UTF8.GetBytes(this.Content));

            return dataStream.ToArray();
        }

    }
}
