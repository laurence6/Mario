namespace MarioPirates
{
    internal sealed class Coins
    {
        public static readonly Coins Ins = new Coins();

        private Coins() { }

        public long Value { get; set; }

        public void Reset()
        {
            Value = 0;
        }
    }
}
