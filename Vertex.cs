using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace BezierSurface
{
    public class Vertex
    {
        public Vector3 P;
        public Vector3 Pu;
        public Vector3 Pv;
        public Vector3 N;

        public Vector3 P_rotated;
        public Vector3 Pu_rotated;
        public Vector3 Pv_rotated;
        public Vector3 N_rotated;

        public double u;
        public double v;
    }
}
