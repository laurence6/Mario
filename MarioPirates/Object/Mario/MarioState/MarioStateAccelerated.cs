namespace MarioPirates
{
    internal class MarioStateAccelerated
    {
        public bool IsAccelerated { get; private set; }

        public MarioStateAccelerated(bool isAccelerated = false) => IsAccelerated = isAccelerated;

        public void SetAccelerated(bool isAccelerated) => IsAccelerated = isAccelerated;

        public float VelocityMultiplier => IsAccelerated ? 10f : 1f;
    }
}
