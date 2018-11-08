namespace MarioPirates
{
    class Timer
    {
        private float originalTime;
        private uint timeLimit;
        private float timeLeft;
        
        public static readonly Timer Ins = new Timer();

        private Timer() { }

        public uint Value => (timeLeft = (timeLimit - Time.Now + originalTime) / 1000) > 0 ? (uint) timeLeft : 0;

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
