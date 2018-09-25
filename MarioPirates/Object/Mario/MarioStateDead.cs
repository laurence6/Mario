using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MarioPirates
{

    public class MarioStateDead : MarioState
    {
        public const int marioWidth = 60, marioHeight = 56;

        public MarioStateDead(Mario mario, int dstX, int dstY) : base(mario, dstX, dstY)
        {
            new Point(marioHeight, marioWidth);
            mario.State = SpriteFactory.Instance.CreateSprite("mario_dead");
        }

        public override void Left()
        {
        }

        public override void Right()
        {
        }

        public override void Jump()
        {
        }

        public override void Crouch()
        {
        }

        public override void Small()
        {
            mario.State = new MarioStateSmallRightIdle(mario, location.X, location.Y);
        }

        public override void Big()
        {
            mario.State = new MarioStateBigRightIdle(mario, location.X, location.Y);
        }

        public override void Fire()
        {
            mario.State = new MarioStateFireRightIdle(mario, location.X, location.Y);
        }

        public override void Dead()
        {
        }
    }

}
