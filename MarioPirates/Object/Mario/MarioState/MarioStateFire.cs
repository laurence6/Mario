using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal abstract class MarioStateFire : MarioState
    {
        protected const int marioWidth = 64, marioHeight = 128;

        protected MarioStateFire(Mario mario) : base(mario)
        {
            mario.Size = new Point(marioWidth, marioHeight);
        }

        public override void Fire()
        {
        }

        public override void Dead()
        {
            mario.State = new MarioStateDead(mario);
        }
    }
}
