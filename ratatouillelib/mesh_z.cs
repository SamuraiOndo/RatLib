using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yarhl.IO;
using ratatouillelib.common

namespace ratatouillelib
{
    public class Mesh_Z
    {
        private Header header;
        private float[][] vertices;
        private int[][] triangles;

        public float[][] getVerts() { return vertices; }
        public int[][] getTriangles() {  return triangles; }
        public Header getHeader() { return header; }
    }
    class ReadMesh_Z
    {
        public Mesh_Z readMesh_Z(DataReader reader)
        {
            Mesh_Z mesh = new Mesh_Z();
            return mesh;
        }
    }
    
}
