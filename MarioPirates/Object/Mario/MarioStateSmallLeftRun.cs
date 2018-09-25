namespace MarioPirates
{

    public class MarioStateSmallLeftRun : MarioStateSmall
    {
        private const uint framesPerSprite = 15;

        private uint frameCount = 0;

        public MarioStateSmallLeftRun(Mario mario, int dstX, int dstY) : base(mario, dstX, dstY)
        {            mario.State = SpriteFactory.Instance.CreateSprite("mario_small_run_left");
        }

        public override void Left()
        {
        }

        public override void Right()
        {
            mario.State = new MarioStateSmallLeftIdle(mario, location.X, location.Y);
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
            mario.State = new MarioStateBigLeftRun(mario, location.X, location.Y);
        }

        public override void Fire()
        {
            mario.State = new MarioStateFireLeftRun(mario, location.X, location.Y);
        }
    }

}
