using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yarhl.IO;
using ratatouillelib.common;

namespace ratatouillelib.formats
{
    public class Mesh_Z
    {
        private Header header;
        private float[][] vertices;
        private int[][] triangles;
        public void mesh_Z() { }
        public float[][] getVerts() { return vertices; }
        public int[][] getTriangles() { return triangles; }
        public Header getHeader() { return header; }

        public void setVerts(float[][] vertices) { this.vertices = vertices; }
        public void setTriangles(int[][] triangles) { this.triangles = triangles; }
        public void setHeader(Header header) { this.header = header; }
        public void readMesh_Z(DataReader reader)
        {
            header = new Header();
            header.readHeader(reader);

        }
    }


}
