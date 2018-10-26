using System;

namespace MarioPirates
{
    [Flags]
    internal enum CollisionLayer : uint
    {
        None = 0,

        Coin,
        Enemy,
        Flower,
        Mushroom,
        Star,

        All = Coin | Enemy | Flower | Mushroom | Star,
    }
}
