using System;

namespace MarioPirates
{
    [Flags]
    internal enum CollisionLayer : uint
    {
        None = 0b0,
        Normal = 0b1,
    }
}
