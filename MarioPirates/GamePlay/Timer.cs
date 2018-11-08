namespace MarioPirates
{
    internal sealed class Timer
    {
        public static readonly Timer Ins = new Timer();

        private Timer() { }

        private float originalTime;
        private uint timeLimit;
        private float timeLeft;

        public uint Value => (timeLeft = (timeLimit - Time.Now + originalTime) / 1000) > 0 ? (uint)timeLeft : 0;

        public void Reset(float originalTime)
        {
            this.originalTime = originalTime;
        }

        public void Reset(float originalTime, uint timeLimit)
        {
            this.originalTime = originalTime;
            this.timeLimit = timeLimit;
        }
    }
}
