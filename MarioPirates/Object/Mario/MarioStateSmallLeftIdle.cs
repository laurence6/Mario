namespace MarioPirates
{

    public class MarioStateSmallLeftIdle : MarioStateSmall
    {
        public MarioStateSmallLeftIdle(Mario mario, int dstX, int dstY) : base(mario, dstX, dstY)
        {
            mario.State = SpriteFactory.Instance.CreateSprite("mario_small_idle_left");
        }

        public override void Left()
        {
            mario.State = new MarioStateSmallLeftRun(mario, location.X, location.Y);
        }

        public override void Right()
        {
            mario.State = new MarioStateSmallRightIdle(mario, location.X, location.Y);
        }

        public override void Jump()
        {
            mario.State = new MarioStateSmallLeftJump(mario, location.X, location.Y);
        }

        public override void Crouch()
        {
            mario.State = new MarioStateSmallLeftCrouch(mario, location.X, location.Y);
        }

        public override void Small()
        {
        }

        public override void Big()
        {
            mario.State = new MarioStateBigLeftIdle(mario, location.X, location.Y);
        }

        public override void Fire()
        {
            mario.State = new MarioStateFireLeftIdle(mario, location.X, location.Y);
        }
    }

}
