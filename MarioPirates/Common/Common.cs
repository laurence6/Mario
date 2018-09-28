using Microsoft.Xna.Framework;
using System;

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

        public static T[] EnumValues<T>()
        {
            return (T[])Enum.GetValues(typeof(T));
        }
    }
}
