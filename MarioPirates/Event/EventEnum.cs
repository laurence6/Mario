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

        KeyXDown,
        KeyXUp,
        KeyXHold,

        KeyDown,
        KeyUp,
        KeyHold,

        GameObjectCreate,
        GameObjectDestroy,
        GameOver,
        Win
    }
}
