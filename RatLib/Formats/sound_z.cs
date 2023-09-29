using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yarhl.IO;
namespace RatLib.Common
{
    public class SoundZ
    {
        Header header;
        public uint frequency;
        public ushort flag;
        public byte[] sound;
        public void ReadSoundZ(DataReader reader)
        {
            this.header = new Header();
            this.header.ReadHeader(reader);
            this.frequency = reader.ReadUInt32();
            uint soundSize = reader.ReadUInt32();
            this.flag = reader.ReadUInt16();
            this.sound = reader.ReadBytes((int)soundSize);
        }
        public byte[] GetSound() 
        { 
            return this.sound;
        }
    }
}
