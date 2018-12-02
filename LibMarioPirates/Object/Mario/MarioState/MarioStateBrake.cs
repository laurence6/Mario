namespace MarioPirates
{
    internal class MarioStateBrake
    {
        private bool brake;

        public MarioStateBrake(bool isBrake = false) => brake = isBrake;

        public void Brake() => brake = true;

        public void Coast() => brake = false;

        public MarioStateEnum State => brake ? MarioStateEnum.Brake : MarioStateEnum.Coast;
    }
}
