using System;

namespace MarioPirates
{
    [Flags]
    internal enum CollisionLayer : uint
    {
        None = 0,
        Normal = 1 << 0,
    }
}
