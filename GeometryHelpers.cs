using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BezierSurface
{
    public static class GeometryHelpers
    {
        public static Vector3 Rotate(Vector3 v, Matrix4x4 rotMatrixZ, Matrix4x4 rotMatrixX)
        {
            return Vector3.Transform(Vector3.Transform(v, rotMatrixZ), rotMatrixX);
        }

        public static Vector3 Rotate(Vector3 v)
        {
            Matrix4x4 rotMatrixZ = Matrix4x4.CreateRotationZ((float)Config.alpha);
            Matrix4x4 rotMatrixX = Matrix4x4.CreateRotationX((float)Config.beta);
            return Vector3.Transform(Vector3.Transform(v, rotMatrixZ), rotMatrixX);
        }

        public static void GenerateCurve(Vector3 start, Vector3 control1, Vector3 control2, Vector3 end, List<Vector3>? points, List<Vector3>? tangents = null, List<double>? indexes = null)
        {
            int numOfPoints = Config.precision - 1;
            float d = 1.0f / (float)numOfPoints;
            float d2 = d * d;
            float d3 = d2 * d;

            Vector3 A0 = start;
            Vector3 A1 = 3 * (control1 - start);
            Vector3 A2 = 3 * (control2 - 2 * control1 + start);
            Vector3 A3 = end - 3 * control2 + 3 * control1 - start;

            Vector3 nextP0 = A0;
            Vector3 nextP1 = A3 * d3 + A2 * d2 + A1 * d;
            Vector3 nextP2 = 6 * A3 * d3 + 2 * A2 * d2;

            Vector3 nextPt0 = A1;
            Vector3 nextPt1 = 3 * A3 * d2 + 2 * A2 * d;

            points?.Add(nextP0);
            tangents?.Add(Vector3.Normalize(nextPt0));

            for (int step = 0; step < numOfPoints; step++)
            {
                nextP0 += nextP1;
                nextP1 += nextP2;
                nextP2 += 6 * A3 * d3;

                nextPt0 += nextPt1;
                nextPt1 += 6 * A3 * d2;

                points?.Add(nextP0);
                tangents?.Add(Vector3.Normalize(nextPt0));
                indexes?.Add(step * d);
            }
            indexes?.Add(1);
        }

        public static Vector3 GetBaricentricCoords(int x, int y, Vector2 v1, Vector2 v2, Vector2 v3)
        {
            Vector2 p = new(x, y);
            Vector3 barCoords = new Vector3();
            float denom = (v2.Y - v3.Y) * (v1.X - v3.X) + (v3.X - v2.X) * (v1.Y - v3.Y);
            barCoords.X = ((v2.Y - v3.Y) * (p.X - v3.X) + (v3.X - v2.X) * (p.Y - v3.Y)) / denom;
            barCoords.Y = ((v3.Y - v1.Y) * (p.X - v3.X) + (v1.X - v3.X) * (p.Y - v3.Y)) / denom;
            barCoords.Z = 1 - barCoords.X - barCoords.Y;
            return barCoords;
        }

        public static Vector3 InterpolatePoint(Vector3 barCoords, Vector3 v1, Vector3 v2, Vector3 v3)
        {
            return new Vector3(
                v1.X * barCoords.X + v2.X * barCoords.Y + v3.X * barCoords.Z,
                v1.Y * barCoords.X + v2.Y * barCoords.Y + v3.Y * barCoords.Z,
                v1.Z * barCoords.X + v2.Z * barCoords.Y + v3.Z * barCoords.Z
            );
        }

        public static double InterpolatePoint(Vector3 barCoords, double a, double b, double c)
        {
            return a * barCoords.X + b * barCoords.Y + c * barCoords.Z;
        }
    }
}
