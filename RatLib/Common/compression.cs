using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yarhl.IO;
/*

        flag = flagmask >> flagbit & 1
        flagbit -= 1
        currentByte = bs.read_uint8()

        if flag == 0:
            windowBuffer[pos & WINDOW_MASK] = currentByte
            pos += 1
            decompressed.write_uint8(currentByte)
        else:
            d = bs.read_uint8()
            j = (currentByte << 8) + d

            length = (j >> lenbits) + 3
            d = (j & (1 << lenbits) - 1) + 1

            for j in range(length):
                currentByte = windowBuffer[pos - d & WINDOW_MASK]
                windowBuffer[pos & WINDOW_MASK] = currentByte
                pos += 1
                decompressed.write_uint8(currentByte)
    return decompressed.buffer()*/
namespace RatLib.common
{
    // not tested. probably incorrect
    class Compression
    {
        public DataStream Decompress(byte[] data)
        {
            int WINDOW_LOG = 14;
            int WINDOW_SIZE = 1 << WINDOW_LOG;
            int WINDOW_MASK = (1 << WINDOW_LOG) - 1;
            var reader = new DataReader(DataStreamFactory.FromArray(data, 0, data.Length));
            uint decompressedSize = reader.ReadUInt32();
            uint compressedSize = reader.ReadUInt32();
            byte[] windowBuffer = new byte[WINDOW_SIZE];
            int flagbit = 0;
            int pos = 0;
            int flagmask = 0;
            int lenbits = 0;
            byte[] decompressed = new byte[decompressedSize];
            var writer = new DataWriter(DataStreamFactory.FromArray(decompressed, 0, decompressed.Length));
            while (writer.Stream.Position < decompressedSize)
            {
                if (flagbit <= 1)
                {
                    flagmask = reader.ReadByte() << 24;
                    flagmask |= reader.ReadByte() << 16;
                    flagmask |= reader.ReadByte() << 8;
                    flagmask |= reader.ReadByte();
                    flagbit = 32 - 1;
                    lenbits = WINDOW_LOG - (flagmask & 3);
                }

            }
            int flag = flagmask >> flagbit & 1;
            flagbit -= 1;
            uint currentByte = reader.ReadByte();
            if (flag == 0)
            {
                windowBuffer[pos & WINDOW_MASK] = (byte)currentByte;
                pos += 1;
                writer.Write(currentByte);
            }
            else
            {
                uint d = reader.ReadByte();
                uint j = (currentByte << 8) + d;

                uint length = (j >> lenbits) + 3;
                d = (uint)((j & (1 << lenbits) - 1) + 1);

                for (j = 0; j < length; j++)
                {
                    currentByte = windowBuffer[pos - d & WINDOW_MASK];
                    windowBuffer[pos & WINDOW_MASK] = (byte)currentByte;
                    pos += 1;
                    writer.Write(currentByte);
                }
            }
            return writer.Stream;
        }
    }
}
