namespace MarioPirates
{
    internal sealed class Timer
    {
        public static readonly Timer Ins = new Timer();

        private Timer() { }

        private float OriginalTime;
        private float TimeLimit;
        private float TimeLeft;
        private bool isFreeze;

        public uint Value => isFreeze ? (uint)TimeLimit / 1000 : ((TimeLeft = (TimeLimit - Time.Now + OriginalTime) / 1000) > 0 ? (uint)TimeLeft : 0);

        public void Reset()
        {
            OriginalTime = Time.Now;
            isFreeze = false;
        }

        public void Reset(float timeLimit)
        {
            OriginalTime = Time.Now;
            TimeLimit = timeLimit;
            isFreeze = false;
        }

        public void Freeze()
        {
            if (!isFreeze)
            {
                isFreeze = true;
                TimeLimit = TimeLimit - Time.Now + OriginalTime;
            }
        }

        public void Unfreeze()
        {
            if (isFreeze)
            {
                isFreeze = false;
                OriginalTime = Time.Now;
            }
        }
    }
}
