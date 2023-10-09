using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yarhl.IO;
using RatLib.Common;

namespace RatLib.Formats
{
    public class BitmapZ
    {
        Header header;
        public uint width;    
        public uint height;   
        public byte format;   
        public byte paletteFormat;
        public byte transpFormat;
        public byte mipCount;
        public ushort flag;
        public bool isDDS = false;
        public byte[] texData;
        public void ReadBitmapZ(string path)
        {
            var reader = new DataReader(DataStreamFactory.FromFile(path, FileOpenMode.Read));
            header = new Header();
            header.ReadHeader(reader);
            width = reader.ReadUInt32();
            height = reader.ReadUInt32();
            uint precalculatedSize = reader.ReadUInt32();
            format = reader.ReadByte();
            reader.ReadByte();
            paletteFormat = reader.ReadByte();
            transpFormat = reader.ReadByte();
            mipCount = reader.ReadByte();
            reader.ReadByte();
            flag = reader.ReadUInt16();
            if (precalculatedSize != 0)
            {
                isDDS = true;
                texData = reader.ReadBytes((int)precalculatedSize);
            }
            else if (format == 12)
            {
                texData = reader.ReadBytes((int)width * (int)height * 4);
            }
            else
            {
                texData = reader.ReadBytes((int)width * (int)height * 3);
            };
        }
    }
}
