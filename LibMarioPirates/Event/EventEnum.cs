namespace MarioPirates
{
    internal enum EventEnum : int
    {
        Action,

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

        KeyDown,
        KeyUp,
        KeyHold,

        MouseButtonDown,
        MouseButtonUp,
        MouseButtonHold,

        GameObjectCreate,
        GameObjectDestroy,
        GameOver,
        Win,
    }
}
