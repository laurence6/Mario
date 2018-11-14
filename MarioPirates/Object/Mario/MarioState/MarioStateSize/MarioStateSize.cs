namespace MarioPirates
{
    internal abstract class MarioStateSize
    {
        protected MarioState state;

        protected MarioStateSize(MarioState state) => this.state = state;

        public virtual void TurnSmall() => state.Size = new MarioStateSmall(state);

        public virtual void TurnBig() => state.Size = new MarioStateBig(state);

        public virtual void TurnFire() => state.Size = new MarioStateFire(state);

        public virtual void TurnDead()
        {
            state.Size = new MarioStateDead(state);
            Lives.Ins.Value--;
        }

        public virtual bool IsDead => false;

        public abstract MarioStateEnum State { get; }
    }
}
