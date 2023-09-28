using ratatouillelib.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yarhl.IO;
/*struct sound_z{
ObjectHeader header;
uint32 frequency;
uint32 soundSize;
uint16 unk<comment="Probably Format">;
ubyte sound[soundSize];
}Sound_Z;*/
namespace ratatouillelib.formats
{
    internal class Sound_Z
    {
        Header header;
        private uint frequency;
        private ushort flag;
        private byte[] sound;
        public void readSound_Z(DataReader reader)
        {
            this.header = new Header();
            this.header.readHeader(reader);
            this.frequency = reader.ReadUInt32();
            uint soundSize = reader.ReadUInt32();
            this.flag = reader.ReadUInt16();
            this.sound = reader.ReadBytes((int)soundSize);
        }
        public byte[] getSound() 
        { 
            return this.sound;
        }
    }
}
