namespace MarioPirates
{

    public class MarioStateBigLeftIdle : MarioStateBig
    {
        public MarioStateBigLeftIdle(Mario mario, int dstX, int dstY) : base(mario, dstX, dstY)
        {
            mario.State = SpriteFactory.Instance.CreateSprite("mario_big_idle_left");
        }

        public override void Left()
        {
            mario.State = new MarioStateBigLeftRun(mario, location.X, location.Y);
        }

        public override void Right()
        {
            mario.State = new MarioStateBigRightIdle(mario, location.X, location.Y);
        }

        public override void Jump()
        {
            mario.State = new MarioStateBigLeftJump(mario, location.X, location.Y);
        }

        public override void Crouch()
        {
            mario.State = new MarioStateBigLeftCrouch(mario, location.X, location.Y);
        }

        public override void Small()
        {
            mario.State = new MarioStateSmallLeftIdle(mario, location.X, location.Y);
        }

        public override void Big()
        {
        }

        public override void Fire()
        {
            mario.State = new MarioStateFireLeftIdle(mario, location.X, location.Y);
        }
    }

}
