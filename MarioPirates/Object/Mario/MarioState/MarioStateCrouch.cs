namespace MarioPirates
{
    internal class MarioStateCrouch : MarioStateAction
    {
        public MarioStateCrouch(MarioState state) : base(state)
        {
        }

        public override void Crouch()
        {
        }

        public override void Run()
        {
        }

        public override MarioStateEnum GetEnum()
        {
            return MarioStateEnum.Crouch;
        }
    }
}
