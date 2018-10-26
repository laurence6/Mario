using System;

namespace MarioPirates
{
    [Flags]
    internal enum CollisionLayer : uint
    {
        None = 0,

        Static = 1 << 1,
        Coin = 1 << 2,
        Enemy = 1 << 3,
        Flower = 1 << 4,
        Mushroom = 1 << 5,
        Star = 1 << 6,

        All = Static | Coin | Enemy | Flower | Mushroom | Star,
    }
}
