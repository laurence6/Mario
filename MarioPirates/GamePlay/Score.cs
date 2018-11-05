namespace MarioPirates
{
    internal sealed class Score
    {
        public static readonly Score Ins = new Score();
        private long _value;

        private Score() { }

        public long Value { get => _value; set { _value = value; System.Console.WriteLine("Score " + Value); } }

        public void Reset()
        {
            Value = 0;
        }
    }
}
