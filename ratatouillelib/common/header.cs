using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yarhl.IO;

namespace ratatouillelib.common
{
    public class Header
    {
        private uint nameCrc32;
        private uint classCrc32;
        private byte[] linkData;
        public Header() { }
        public void readHeader(DataReader reader)
        {
            uint dataSize = reader.ReadUInt32();
            uint linkSize = reader.ReadUInt32();
            uint decompressedSize = reader.ReadUInt32();
            uint compressedSize = reader.ReadUInt32();
            this.classCrc32 = reader.ReadUInt32();
            this.nameCrc32 = reader.ReadUInt32();
            this.linkData = reader.ReadBytes(Convert.ToInt32(linkSize));
        }
        public uint getNameCrc32() {  return this.nameCrc32; }
    }
}
