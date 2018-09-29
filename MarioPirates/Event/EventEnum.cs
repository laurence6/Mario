namespace MarioPirates.Event
{
    internal enum EventEnum : int
    {
        // Common input
        KeyUpDown,
        KeyDownDown,
        KeyLeftDown,
        KeyRightDown,
        KeyUpUp,
        KeyDownUp,
        KeyLeftUp,
        KeyRightUp,

        // Generic keyboard input
        KeyDown,
        KeyUp,

        // Generic gamepad input
        ButtonDown,
        ButtonUp,

        // 
        Collide,
    }
}
