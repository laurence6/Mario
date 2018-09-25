namespace MarioPirates
{

    public class MarioStateBigRightIdle : MarioStateBig
    {
        public MarioStateBigRightIdle(Mario mario, int dstX, int dstY) : base(mario, dstX, dstY)
        {
            mario.State = SpriteFactory.Instance.CreateSprite("mario_big_idle_right");
        }

        public override void Left()
        {
            mario.State = new MarioStateBigLeftIdle(mario, location.X, location.Y);
        }

        public override void Right()
        {
            mario.State = new MarioStateBigRightRun(mario, location.X, location.Y);
        }

        public override void Jump()
        {
            mario.State = new MarioStateBigRightJump(mario, location.X, location.Y);
        }

        public override void Crouch()
        {
            mario.State = new MarioStateBigRightCrouch(mario, location.X, location.Y);
        }

        public override void Small()
        {
            mario.State = new MarioStateSmallRightIdle(mario, location.X, location.Y);
        }

        public override void Big()
        {
        }

        public override void Fire()
        {
            mario.State = new MarioStateFireRightIdle(mario, location.X, location.Y);
        }
    }

}
