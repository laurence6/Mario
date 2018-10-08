namespace MarioPirates
{
    internal abstract class MarioStateSize
    {
        protected Mario mario;

        protected MarioStateSize(Mario mario)
        {
            this.mario = mario;
        }

        public virtual void Small()
        {
            mario.State.Size = new MarioStateSmall(mario);
        }

        public virtual void Big()
        {
            mario.State.Size = new MarioStateBig(mario);
        }

        public virtual void Fire()
        {
            mario.State.Size = new MarioStateFire(mario);
        }

        public virtual void Dead()
        {
            mario.State.Size = new MarioStateDead(mario);
        }

        public virtual bool IsDead => false;

        public abstract MarioStateEnum State { get; }
    }
}
