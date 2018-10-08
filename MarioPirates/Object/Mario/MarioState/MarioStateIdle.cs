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

        public override MarioStateEnum GetEnum()
        {
            return MarioStateEnum.Idle;
        }
    }
}
