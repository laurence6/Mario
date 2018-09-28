namespace MarioPirates.Event
{
    internal enum EventEnum
    {
        // Game
        Quit,
        Reset,

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
        Key,

        // Generic gamepad input
        Button,

        // 
        Collide,
    }
}
