using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using Yarhl.IO;
using ratatouillelib.formats;
using ratatouillelib.common;

namespace ratatouillelib
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
                    Mesh_Z mesh_z = new Mesh_Z();
                    mesh_z.readMesh_Z(reader);
                    Debug.WriteLine(mesh_z.getHeader().getNameCrc32());
                }
                if (type.ToLower().Equals("bitmap_z"))
                {
                    Bitmap_Z bitmap_z = new Bitmap_Z();
                    bitmap_z.readBitmap_Z(reader);
                    Debug.WriteLine(bitmap_z.getHeader().getNameCrc32());
                    Debug.WriteLine(Convert.ToHexString(bitmap_z.getTexData()));
                }
            }
        }
    }
}