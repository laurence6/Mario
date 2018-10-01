using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal abstract class MarioStateSmall : MarioState
    {
        protected const int marioWidth = 68, marioHeight = 60;

        protected MarioStateSmall(Mario mario) : base(mario)
        {
            mario.Size = new Point(marioWidth, marioHeight);
        }

        public override void Left()
        {
            mario.State = new MarioStateSmallLeftIdle(mario);
        }

        public override void Right()
        {
            mario.State = new MarioStateSmallRightIdle(mario);
        }
    }
}