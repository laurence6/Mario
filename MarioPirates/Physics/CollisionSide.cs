namespace MarioPirates
{
    internal enum CollisionSide : byte
    {
        None = 0b0000,
        Top = 0b0001, Bottom = 0b0010, Left = 0b0100, Right = 0b1000,
        All = Top | Bottom | Left | Right,
    }
}
