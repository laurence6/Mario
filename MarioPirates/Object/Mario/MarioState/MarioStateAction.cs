namespace MarioPirates
{
    internal abstract class MarioStateAction
    {
        protected MarioState state;

        protected MarioStateAction(MarioState state)
        {
            this.state = state;
        }

        public virtual void Idle()
        {
            state.Action = new MarioStateIdle(state);
        }

        public virtual void Run()
        {
            state.Action = new MarioStateRun(state);
        }

        public virtual void Jump()
        {
            state.Action = new MarioStateJump(state);
        }

        public virtual void Crouch()
        {
            state.Action = new MarioStateCrouch(state);
        }

        public abstract MarioStateEnum State { get; }
    }
}
