namespace MarioPirates
{
    internal class MarioStateJump : MarioStateAction
    {
        public MarioStateJump(MarioState state) : base(state)
        {
        }

        public override void Jump()
        {
        }

        public override void Run()
        {
        }

        public override MarioStateEnum GetEnum()
        {
            return MarioStateEnum.Jump;
        }
    }
}
