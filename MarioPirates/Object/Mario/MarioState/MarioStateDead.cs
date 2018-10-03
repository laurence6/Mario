using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal class MarioStateDead : MarioState
    {
        protected const int marioWidth = 60, marioHeight = 56;

        public MarioStateDead(Mario mario) : base(mario)
        {
            mario.Size = new Point(marioWidth, marioHeight);
            mario.Sprite = SpriteFactory.Instance.CreateSprite("dead");
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
            mario.State = new MarioStateSmallRightIdle(mario);
        }

        public override void Big()
        {
            mario.State = new MarioStateBigRightIdle(mario);
        }

        public override void Fire()
        {
            mario.State = new MarioStateFireRightIdle(mario);
        }

        public override void Star()
        {
            mario.State = new MarioStateStarSmallRightIdle(mario);
        }

        public override void Dead()
        {
        }
    }
}
