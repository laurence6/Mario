using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace MarioPirates
{
    internal static class Common
    {
        public static Point P(int X, int Y) => new Point(X, Y);

        public static void Swap<T>(ref T o1, ref T o2)
        {
            var tmp = o1;
            o1 = o2;
            o2 = tmp;
        }

        public static T[] EnumValues<T>() => (T[])Enum.GetValues(typeof(T));

        public static void AddIfNotExist<T, U>(this Dictionary<T, U> d, T key, U val)
        {
            if (!d.ContainsKey(key))
                d.Add(key, val);
        }

        public static float Pow(float x, float y) => (float)Math.Pow(x, y);

        public static Point Mul(this Point p, int n) => new Point(p.X * n, p.Y * n);

        public static Vector2 Abs(this Vector2 v) => new Vector2(Math.Abs(v.X), Math.Abs(v.Y));

        public static Vector2 DivS(this Vector2 v1, Vector2 v2) => new Vector2(v2.X == 0 ? 0 : v1.X / v2.X, v2.Y == 0 ? 0 : v1.Y / v2.Y);
    }
}
