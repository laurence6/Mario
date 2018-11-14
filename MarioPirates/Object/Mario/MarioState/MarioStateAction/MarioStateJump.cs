namespace MarioPirates
{
    internal class MarioStateJump : MarioStateAction
    {
        public MarioStateJump(MarioState state) : base(state)
        {
        }

        public override void TurnJump()
        {
        }

        public override MarioStateEnum State => MarioStateEnum.Jump;
    }
}
