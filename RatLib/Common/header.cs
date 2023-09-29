using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yarhl.IO;

namespace RatLib.Common
{
    public class Header
    {
        public uint nameCrc32;
        public uint classCrc32;
        public byte[] linkData;
        public Header() { }
        public void ReadHeader(DataReader reader)
        {
            uint dataSize = reader.ReadUInt32();
            uint linkSize = reader.ReadUInt32();
            uint decompressedSize = reader.ReadUInt32();
            uint compressedSize = reader.ReadUInt32();
            this.classCrc32 = reader.ReadUInt32();
            this.nameCrc32 = reader.ReadUInt32();
            this.linkData = reader.ReadBytes(Convert.ToInt32(linkSize));
        }
        public uint GetNameCrc32() {  return this.nameCrc32; }
        public uint GetClassCrc32() { return this.classCrc32; }
        public byte[] GetLinkData() {  return this.linkData; }
    }
}
