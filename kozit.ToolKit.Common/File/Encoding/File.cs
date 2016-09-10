using System;
using System.Collections.Generic;

namespace kozit.ToolKit.Common.File.Encoding
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

            this.Name = System.Text.Encoding.UTF8.GetString(DataStream,8,nameLength);
            this.Content = System.Text.Encoding.UTF8.GetString(DataStream, 8 + nameLength, contentLength);

        }

        public byte[] GetDataStream()
        {

            List<byte> dataStream = new List<byte>();

            dataStream.AddRange(BitConverter.GetBytes(this.Name.Length));
            dataStream.AddRange(BitConverter.GetBytes(this.Content.Length));
            dataStream.AddRange(System.Text.Encoding.UTF8.GetBytes(this.Name));
            dataStream.AddRange(System.Text.Encoding.UTF8.GetBytes(this.Content));

            return dataStream.ToArray();
        }

    }
}
