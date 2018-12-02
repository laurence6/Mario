using System;

namespace MarioPirates.Controller
{
    [Flags]
    internal enum InputState : byte
    {
        None = 0b00, Down = 0b01, Up = 0b10, Hold = 0b11,
    }
}
