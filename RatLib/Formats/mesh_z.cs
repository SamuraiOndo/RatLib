﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yarhl.IO;
using RatLib.Common;

namespace RatLib.Formats
{
    public class MeshZ
    {
        public Header header;
        public float[][] vertices;
        public int[][] triangles;
        public void mesh_Z() { }
        public void ReadMeshZ(string path)
        {
            var reader = new DataReader(DataStreamFactory.FromFile(path, FileOpenMode.Read));
            header = new Header();
            header.ReadHeader(reader);

        }
    }


}
