using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal abstract class MarioStateFire : MarioState
    {
        protected const int marioWidth = 120, marioHeight = 132;
        protected const int marioCrouchWidth = 64, marioCrouchHeight = 88;

        protected MarioStateFire(Mario mario) : base(mario)
        {
            mario.Size = new Point(marioWidth, marioHeight);
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
