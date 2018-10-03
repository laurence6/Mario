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
        KeyUpHold,
        KeyDownHold,
        KeyLeftHold,
        KeyRightHold,

        // Generic keyboard input
        KeyDown,
        KeyUp,
        KeyHold,

        // 
        Collide,
        GameObjectDestroy,
    }
}
