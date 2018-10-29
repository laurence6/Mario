namespace MarioPirates
{
    internal class MarioStateTransiting
    {
        public bool IsTransiting { get; private set; }

        public MarioStateTransiting(bool isTransiting = false) => IsTransiting = isTransiting;

        public void SetTransiting(bool isTransiting) => IsTransiting = isTransiting;

        public MarioStateEnum State => IsTransiting ? MarioStateEnum.Transiting : MarioStateEnum.NonTransiting;
    }
}
