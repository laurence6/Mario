using Microsoft.Xna.Framework;

namespace MarioPirates
{

    public abstract class MarioStateFire : MarioState
    {
        public const int marioWidth = 120, marioHeight = 132;
        public const int marioCrouchWidth = 64, marioCrouchHeight = 88;

        protected MarioStateFire(Mario mario) : base(mario)
        {
            mario.size = new Point(marioWidth, marioHeight);
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
