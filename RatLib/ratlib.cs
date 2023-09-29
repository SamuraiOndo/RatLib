using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using Yarhl.IO;
using RatLib.Formats;
using RatLib.Common;

namespace RatLib
{
    public class ratlib
    {
        public static void ReadFile(string path, string type)
        {
            using (var stream = DataStreamFactory.FromFile(path, FileOpenMode.Read))
            {
                var reader = new DataReader(stream)
                {
                    DefaultEncoding = Encoding.GetEncoding("utf-8"),
                    Endianness = EndiannessMode.LittleEndian,
                };
                if (type.ToLower().Equals("mesh_z"))
                {
                    MeshZ mesh_z = new MeshZ();
                    mesh_z.ReadMeshZ(reader);
                    Debug.WriteLine(mesh_z.header.GetNameCrc32());
                }
                if (type.ToLower().Equals("bitmap_z"))
                {
                    BitmapZ bitmap_z = new BitmapZ();
                    bitmap_z.ReadBitmapZ(reader);
                    Debug.WriteLine(bitmap_z.GetHeader().GetNameCrc32());
                    Debug.WriteLine(Convert.ToHexString(bitmap_z.GetTexData()));
                }
                if (type.ToLower().Equals("sound_z"))
                {
                    SoundZ sound_z = new SoundZ();
                    sound_z.ReadSoundZ(reader);
                    Debug.WriteLine(Convert.ToHexString(sound_z.GetSound()));
                }
                if (type.ToLower().Equals("decompress"))
                {
                    Debug.WriteLine("Decompression.");
                    Compression.Decompress(reader);
                }
            }
        }
    }
}