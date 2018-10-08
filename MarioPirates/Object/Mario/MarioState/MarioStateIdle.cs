namespace MarioPirates
{
    internal class MarioStateIdle : MarioStateAction
    {
        public MarioStateIdle(MarioState state) : base(state)
        {
        }

        public override void Idle()
        {
        }

        public override MarioStateEnum State => MarioStateEnum.Idle;
    }
}
