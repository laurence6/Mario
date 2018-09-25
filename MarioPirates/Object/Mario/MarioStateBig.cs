using Microsoft.Xna.Framework;

namespace MarioPirates
{

    public abstract class MarioStateBig : MarioState
    {
        public const int marioWidth = 120, marioHeight = 128;
        public const int marioCrouchWidth = 64, marioCrouchHeight = 88;

        protected MarioStateBig(Mario mario) : base(mario)
        {
            mario.size = new Point(marioWidth, marioHeight);
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
