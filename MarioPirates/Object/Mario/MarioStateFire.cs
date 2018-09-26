using Microsoft.Xna.Framework;

namespace MarioPirates
{

    public abstract class MarioStateFire : MarioState
    {
        public const int marioWidth = 120, marioHeight = 132;

        protected MarioStateFire(Mario mario) : base(mario)
        {
            new Point(marioHeight, marioWidth);
        }

        public override void Left()
        {
            mario.State = new MarioStateFireLeftIdle(mario);
        }

        public override void Right()
        {
            mario.State = new MarioStateFireRightIdle(mario);
        }
    }

}
