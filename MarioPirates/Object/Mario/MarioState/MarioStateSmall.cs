using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal abstract class MarioStateSmall : MarioState
    {
        protected const int marioWidth = 34, marioHeight = 30;

        protected MarioStateSmall(Mario mario) : base(mario)
        {
            mario.Size = new Point(marioWidth, marioHeight);
        }

        public override void Small()
        {
        }

        public override void Dead()
        {
            mario.State = new MarioStateDead(mario);
        }
    }
}
