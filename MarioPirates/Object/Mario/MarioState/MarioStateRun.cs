namespace MarioPirates
{
    internal class MarioStateRun : MarioStateAction
    {
        public MarioStateRun(MarioState state) : base(state)
        {
        }

        public override void Run()
        {
        }

        public override MarioStateEnum State => MarioStateEnum.Run;
    }
}
