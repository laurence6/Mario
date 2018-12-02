namespace MarioPirates
{
    internal class MarioStateCrouch : MarioStateAction
    {
        public MarioStateCrouch(MarioState state) : base(state)
        {
        }

        public override void TurnCrouch()
        {
        }

        public override void TurnRun()
        {
        }

        public override MarioStateEnum State => MarioStateEnum.Crouch;
    }
}
