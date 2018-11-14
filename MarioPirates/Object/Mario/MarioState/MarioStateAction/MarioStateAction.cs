namespace MarioPirates
{
    internal abstract class MarioStateAction
    {
        protected MarioState state;

        protected MarioStateAction(MarioState state) => this.state = state;

        public virtual void TurnIdle() => state.Action = new MarioStateIdle(state);

        public virtual void TurnRun() => state.Action = new MarioStateRun(state);

        public virtual void TurnJump() => state.Action = new MarioStateJump(state);

        public virtual void TurnCrouch() => state.Action = new MarioStateCrouch(state);

        public abstract MarioStateEnum State { get; }
    }
}
