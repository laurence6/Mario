using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal abstract class MarioStateBig : MarioState
    {
        protected const int marioWidth = 32, marioHeight = 64;

        protected MarioStateBig(Mario mario) : base(mario)
        {
            mario.Size = new Point(marioWidth, marioHeight);
        }

        public override void Big()
        {
        }

        public override void Dead()
        {
            mario.State = new MarioStateDead(mario);
        }
    }
}
