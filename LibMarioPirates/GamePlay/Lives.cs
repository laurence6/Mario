namespace MarioPirates
{
    internal sealed class Lives
    {
        public static readonly Lives Ins = new Lives();

        private Lives() { }

        private long _value;
        public long Value { get => _value; set { _value = value; if (value == 0) { EventManager.Ins.RaiseEvent(EventEnum.GameOver, this, null); } } }

        public void Reset()
        {
            Value = Constants.LIVES_RESET;
        }
    }
}
