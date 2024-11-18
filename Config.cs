using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BezierSurface
{
    public static class Config
    {
        public static int precision = 10;
        public static float alpha = 10.0f / 180.0f * (float)Math.PI;
        public static float beta = 60.0f / 180.0f * (float)Math.PI;

        public static float kd = 0.5f;
        public static float ks = 0.5f;
        public static float m = 10;

        public static int refreshRate = 60;

        public static Color meshColor = Color.Black;
        public static Color surfaceColor = Color.Red;
        public static Color lightColor = Color.White;
        public static int lightHeight = 100;
        public static bool lightOmnidir = true;
        public static int mL = 5;

        public static DirectBitmap? texture;
        public static DirectBitmap? normalMap;
        public static bool useNormalMap = false;
    }
}
