namespace MarioPirates
{
    internal sealed class Lives
    {
        public static readonly Lives Ins = new Lives();

        private Lives() { }

        public long Value { get; set; }

        public void Reset()
        {
            Value = Constants.LIVES_RESET; //3
        }
    }
}
