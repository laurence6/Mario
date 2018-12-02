namespace MarioPirates
{
    internal class MarioStateTransiting
    {
        public bool IsTransiting { get; set; }

        public MarioStateTransiting(bool isTransiting = false) => IsTransiting = isTransiting;
    }
}
