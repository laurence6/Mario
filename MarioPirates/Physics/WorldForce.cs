using System;

namespace MarioPirates
{
    [Flags]
    internal enum WorldForce : byte
    {
        None = 0x0,
        Gravity = 0x1,
        Friction = 0x2,
    }
}
