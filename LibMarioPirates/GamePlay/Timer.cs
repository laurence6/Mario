namespace MarioPirates
{
    internal sealed class Timer
    {
        public static readonly Timer Ins = new Timer();

        private Timer() { }

        private float originalTime;
        private float timeLimit;
        private float timeLeft;
        private bool isFreeze;

        public uint Value => isFreeze ? (uint)timeLimit / 1000 : ((timeLeft = (timeLimit - Time.Now + originalTime) / 1000) > 0 ? (uint)timeLeft : 0);

        public void Reset()
        {
            originalTime = Time.Now;
            timeLimit = Constants.DEFAULT_TIME_LIMIT;
            isFreeze = false;
        }

        public void Freeze()
        {
            if (!isFreeze)
            {
                isFreeze = true;
                timeLimit = timeLimit - Time.Now + originalTime;
            }
        }

        public void Unfreeze()
        {
            if (isFreeze)
            {
                isFreeze = false;
                originalTime = Time.Now;
            }
        }
    }
}
