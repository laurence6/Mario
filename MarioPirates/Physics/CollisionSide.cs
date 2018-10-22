using Microsoft.Xna.Framework;
using System;

namespace MarioPirates
{
    [Flags]
    internal enum CollisionSide : byte
    {
        None = 0,
        Top = 1 << 0,
        Bottom = 1 << 1,
        Left = 1 << 2,
        Right = 1 << 3,
        TopBottom = Top | Bottom,
        LeftRight = Left | Right,
        TopLeft = Top | Left,
        TopRight = Top | Right,
        BottomLeft = Bottom | Left,
        BottomRight = Bottom | Right,
        All = TopBottom | LeftRight,
    }

    internal static class CollisionSideMethods
    {
        public static CollisionSide Invert(this CollisionSide side) => (CollisionSide)(
            ((byte)(side & CollisionSide.TopLeft) << 1)
            |
            ((byte)(side & CollisionSide.BottomRight) >> 1)
        );

        public static Vector2 Select(this CollisionSide side, Vector2 v) =>
            new Vector2(
                side.HasOne(CollisionSide.LeftRight) ? v.X : 0,
                side.HasOne(CollisionSide.TopBottom) ? v.Y : 0);

    }
}
