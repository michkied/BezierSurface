using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BezierSurface
{
    public static class LightSource
    {
        public static Vector3 source = new Vector3(revolutionRadius, 0, Config.lightHeight);

        public static float revolutionRadius = 100;
        public static int revolutionPeriod = 10_000;
        public static float angularVelocity = (float)(2 * Math.PI / (float)revolutionPeriod);

        public static void Move(ref int time)
        {
            float angle = angularVelocity * time;
            float x = revolutionRadius * (float)Math.Cos(angle);
            float y = revolutionRadius * (float)Math.Sin(angle);

            source = new Vector3(x, y, Config.lightHeight);

            time += 1000 / (revolutionPeriod / 1000);
            if (time >= revolutionPeriod)
                time -= revolutionPeriod;
        }
    }
}
