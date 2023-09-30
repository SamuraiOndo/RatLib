using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yarhl.IO;
/*def decompress(data):
    WINDOW_LOG = 14
    WINDOW_SIZE = 1 << WINDOW_LOG
    WINDOW_MASK = (1 << WINDOW_LOG) - 1

    bs = BinaryReader(data)
    bs.set_endian(False)
    decompressedSize = bs.read_uint32()
    compressedSize = bs.read_uint32()
    windowBuffer = bytearray(WINDOW_SIZE)
    decompressed = BinaryReader()
    flagbit = 0
    pos = 0
    while decompressed.size() != decompressedSize:
        if flagbit <= 1:
            flagmask = bs.read_uint8() << 24
            flagmask |= bs.read_uint8() << 16
            flagmask |= bs.read_uint8() << 8
            flagmask |= bs.read_uint8()
            flagbit = 32 - 1
            lenbits = WINDOW_LOG - (flagmask & 3)

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
namespace RatLib.Common
{
    class Compression
    {
        /// <summary>
        /// Decompress Asobo LZR Compression
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Returns a DataStream object</returns>
        public static DataStream Decompress(DataReader reader)
        {
            int WINDOW_LOG = 14;
            int WINDOW_SIZE = 1 << WINDOW_LOG;
            int WINDOW_MASK = (1 << WINDOW_LOG) - 1;
            uint decompressedSize = reader.ReadUInt32();
            uint compressedSize = reader.ReadUInt32();
            byte[] windowBuffer = new byte[WINDOW_SIZE];
            int flagbit = 0;
            int pos = 0;
            int flagmask = 0;
            int lenbits = 0;
            int flag = 0;
            int j = 0;
            int d = 0;
            int length = 0;
            byte currentByte = 0;
            var writer = new DataWriter(DataStreamFactory.FromFile("D:\\decompressed", FileOpenMode.Write));
            while (writer.Stream.Length != decompressedSize)
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

                flag = flagmask >> flagbit & 1;
                flagbit -= 1;
                currentByte = reader.ReadByte();

                if (flag == 0)
                {
                    windowBuffer[pos & WINDOW_MASK] = currentByte;
                    pos += 1;
                    writer.Write(currentByte);
                }
                else
                {
                    d = reader.ReadByte();
                    j = (currentByte << 8) + d;

                    length = (j >> lenbits) + 3;
                    d = (j & (1 << lenbits) - 1) + 1;

                    for (j = 0; j < length; j++)
                    {
                        currentByte = windowBuffer[pos - d & WINDOW_MASK];
                        windowBuffer[pos & WINDOW_MASK] = currentByte;
                        pos += 1;
                        writer.Write(currentByte);
                    }
                }

            }
            writer.Write(currentByte);
            return writer.Stream;
        }
    }
}
