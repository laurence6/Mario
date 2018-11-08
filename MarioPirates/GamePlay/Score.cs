namespace MarioPirates
{
    internal sealed class Score
    {
        public static readonly Score Ins = new Score();

        private Score() { }

        public long Value { get; set; }

        public void Reset()
        {
            Value = 0;
        }
    }
}
