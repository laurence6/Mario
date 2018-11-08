namespace MarioPirates
{
    internal abstract class MarioStateSize
    {
        protected MarioState state;

        protected MarioStateSize(MarioState state) => this.state = state;

        public virtual void Small() => state.Size = new MarioStateSmall(state);

        public virtual void Big() => state.Size = new MarioStateBig(state);

        public virtual void Fire() => state.Size = new MarioStateFire(state);

        public virtual void Dead()
        {
            state.Size = new MarioStateDead(state);
            Lives.Ins.Value--;
        }

        public virtual bool IsDead => false;

        public abstract MarioStateEnum State { get; }
    }
}
