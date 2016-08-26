using System;
using System.Collections.Generic;

namespace Cosmos.ToolKit.Common.File.Encoding
{
    public class Content
    {
        List<File> Files = new List<File>();
        public Content()
        { }

        public Content(byte[] DataStream)
        {

            int Filesc = BitConverter.ToInt32(DataStream, 0);

            int Offset = 0;

            for (int i = 0; i < Filesc; i++)
            {
                int temp = BitConverter.ToInt32(DataStream, Offset);
                Offset += 4;
                byte[] tempdata = new byte[temp];
                Buffer.BlockCopy(DataStream,Offset,tempdata,0,temp);

                Files.Add(new File(tempdata));
                Offset +=  temp;
            }
        }

        public byte[] GetDataStream()
        {

            List<byte> dataStream = new List<byte>();

           dataStream.AddRange(BitConverter.GetBytes(Files.Count));

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

        public string GetContent(string name)
        {
            string Return = "File Not Found";
            for (int i = 0; i < Files.Count; i++)
            {
                if (Files[i].Name == name)
                {
                    Return = Files[i].Content;
                }       
            }
            return Return;
        }

    }
}
