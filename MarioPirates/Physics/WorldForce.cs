using System;

namespace MarioPirates
{
    [Flags]
    internal enum WorldForce : byte
    {
        None = 0,
        Gravity = 1 << 0,
        Friction = 1 << 1,
    }
}
