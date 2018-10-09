using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace MarioPirates
{
    internal static class Common
    {
        public static void Swap<T>(ref T o1, ref T o2)
        {
            var tmp = o1;
            o1 = o2;
            o2 = tmp;
        }

        public static void NotNullThen<T>(this T self, Action f) where T : class
        {
            if (self != null)
                f();
        }

        // Enum
        public static T[] EnumValues<T>() => (T[])Enum.GetValues(typeof(T));

        // Array
        public static void ForEach<T>(this T[] a, Action<T> f)
        {
            foreach (var e in a)
                f(e);
        }

        // List
        public static void AddIfNotExist<T>(this List<T> l, T val)
        {
            if (!l.Contains(val))
                l.Add(val);
        }

        public static void Consume<T>(this List<T> l, Action<T> f)
        {
            l.ForEach(f);
            l.Clear();
        }

        // Dictionary
        public static void AddIfNotExist<T, U>(this Dictionary<T, U> d, T key, U val)
        {
            if (!d.ContainsKey(key))
                d.Add(key, val);
        }

        public static void ForEach<T, U>(this Dictionary<T, U> d, Action<T, U> f)
        {
            foreach (var p in d)
                f(p.Key, p.Value);
        }

        public static void Consume<T, U>(this Dictionary<T, U> d, Action<T, U> f)
        {
            d.ForEach(f);
            d.Clear();
        }

        // int
        public static int Abs(this int x) => Math.Abs(x);
        public static float Abs(this float x) => Math.Abs(x);

        // float
        public static float Pow(float x, float y) => (float)Math.Pow(x, y);

        // Vector2
        public static Vector2 Abs(this Vector2 v) => new Vector2(Math.Abs(v.X), Math.Abs(v.Y));

        public static Vector2 DivS(this Vector2 v1, Vector2 v2) =>
            new Vector2(v2.X == 0 ? 0 : (v1.X / v2.X), v2.Y == 0 ? 0 : (v1.Y / v2.Y));
        public static Vector2 DivS(this Vector2 v1, float v2) =>
            v2 != 0 ? v1 / v2 : Vector2.Zero;

        public static Vector2 DeEPS(this Vector2 v) => new Vector2(v.X.Abs() < 1f ? 0f : v.X, v.Y.Abs() < 1f ? 0f : v.Y);
    }
}
