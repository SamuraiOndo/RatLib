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
    public class RatLib
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
            }
        }
    }
}