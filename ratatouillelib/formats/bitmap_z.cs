using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yarhl.IO;
using ratatouillelib.common;

namespace ratatouillelib.formats
{
    internal class Bitmap_Z
    {
        Header header;
        private uint width;
        private uint height;
        private byte format;
        private byte paletteFormat;
        private byte transpFormat;
        private byte mipCount;
        private ushort flag;
        private byte[] texData;
        public void readBitmap_Z(DataReader reader)
        {
            this.header = new Header();
            this.header.readHeader(reader);
            this.width = reader.ReadUInt32();
            this.height = reader.ReadUInt32();
            uint precalculatedSize = reader.ReadUInt32();
            this.format = reader.ReadByte();
            reader.ReadByte();
            this.paletteFormat = reader.ReadByte();
            this.transpFormat = reader.ReadByte();
            this.mipCount = reader.ReadByte();
            reader.ReadByte();
            this.flag = reader.ReadUInt16();
            if (precalculatedSize != 0)
            {
                this.texData = reader.ReadBytes((int)precalculatedSize);
            }
            else if (format == 12)
            {
                this.texData = reader.ReadBytes((int)width * (int)height * 4);
            }
            else
            {
                this.texData = reader.ReadBytes((int)width * (int)height * 3);
            };
        }
        public byte[] getTexData()
        {
            return this.texData;
        }
        public Header getHeader() 
        { 
            return this.header;
        }
    }
}
