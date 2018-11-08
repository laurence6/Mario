namespace MarioPirates
{
    internal sealed class Timer
    {
        public static readonly Timer Ins = new Timer();

        private Timer() { }

        private float OriginalTime;
        private uint TimeLimit;
        private float TimeLeft;

        public uint Value => (TimeLeft = (TimeLimit - Time.Now + OriginalTime) / 1000) > 0 ? (uint)TimeLeft : 0;

        public void Reset(float originalTime)
        {
            OriginalTime = originalTime;
        }

        public void Reset(float originalTime, uint timeLimit)
        {
            OriginalTime = originalTime;
            TimeLimit = timeLimit;
        }
    }
}
