using System;
using System.Collections.Generic;
using System.IO;
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
        public void ReadSoundZ(string path)
        {
            var reader = new DataReader(DataStreamFactory.FromFile(path, FileOpenMode.Read));
            header = new Header();
            header.ReadHeader(reader);
            frequency = reader.ReadUInt32();
            uint soundSize = reader.ReadUInt32();
            flag = reader.ReadUInt16();
            sound = reader.ReadBytes((int)soundSize);
        }
        public byte[] GetSound() 
        { 
            return sound;
        }
    }
}
