using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using Yarhl.IO;

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
                    Endianness = EndiannessMode.BigEndian,
                };
                if (type.ToLower().Equals("mesh_z")){
                    Debug.WriteLine("This is a Mesh_Z");
                }
            }
        }
    }
}