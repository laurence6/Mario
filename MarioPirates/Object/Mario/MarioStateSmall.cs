using Microsoft.Xna.Framework;

namespace MarioPirates
{

    public abstract class MarioStateSmall : MarioState
    {
        public const int marioWidth = 120, marioHeight = 60;

        protected MarioStateSmall(Mario mario) : base(mario)
        {
            new Point(marioHeight, marioWidth);
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
