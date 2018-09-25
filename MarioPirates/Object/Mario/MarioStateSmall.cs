using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MarioPirates
{

    public abstract class MarioStateSmall : MarioState
    {
        public const int marioWidth = 120, marioHeight = 60;

        protected MarioStateSmall(Mario mario, int dstX, int dstY) : base(mario, dstX, dstY)
        {
            new Point(marioHeight, marioWidth);
        }

        public override void Left()
        {
            mario.State = new MarioStateSmallLeftIdle(mario, location.X, location.Y);
        }

        public override void Right()
        {
            mario.State = new MarioStateSmallRightIdle(mario, location.X, location.Y);
        }
    }

}
