using Microsoft.Xna.Framework;

namespace MarioPirates
{

    public abstract class MarioStateBig : MarioState
    {
        public const int marioWidth = 120, marioHeight = 128;

        protected MarioStateBig(Mario mario) : base(mario)
        {
            new Point(marioHeight, marioWidth);
        }

        public override void Left()
        {
            mario.State = new MarioStateBigLeftIdle(mario);
        }

        public override void Right()
        {
            mario.State = new MarioStateBigRightIdle(mario);
        }
    }

}
