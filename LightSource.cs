using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BezierSurface
{
    public class LightSource
    {
        public Vector3 source;
        public Vector3 sourceTransformed
        {
            get
            {
                Matrix4x4 rotMatrixZ = Matrix4x4.CreateRotationZ((float)MainWindow.alpha);
                Matrix4x4 rotMatrixX = Matrix4x4.CreateRotationX((float)MainWindow.beta);

                return Vector3.Transform(Vector3.Transform(source, rotMatrixZ), rotMatrixX);
            }
        }

        public int height = 100;

        public bool rotateLight = true;
        public static float revolutionRadius = 100;
        public static int revolutionPeriodMs = 5_000;
        public static float angularVelocity = (float)(2 * Math.PI / (float)revolutionPeriodMs);

        public LightSource()
        {
            source = new Vector3(revolutionRadius, 0, height);
        }

        public void Rotate(ref int time)
        {
            float angle = angularVelocity * time;
            float x = revolutionRadius * (float)Math.Cos(angle);
            float y = revolutionRadius * (float)Math.Sin(angle);

            source = new Vector3(x, y, height);

            time += 1000 / (revolutionPeriodMs / 1000);
            if (time >= revolutionPeriodMs)
                time -= revolutionPeriodMs;

        }
    }
}
