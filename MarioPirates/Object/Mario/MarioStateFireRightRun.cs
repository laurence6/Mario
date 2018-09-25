namespace MarioPirates
{

    public class MarioStateFireRightRun : MarioStateFire
    {
        private const uint framesPerSprite = 15;
        private uint frameCount = 0;

        public MarioStateFireRightRun(Mario mario, int dstX, int dstY) : base(mario, dstX, dstY)
        {
                mario.State = SpriteFactory.Instance.CreateSprite("mario_fire_run_right");
        }

        public override void Left()
        {
            mario.State = new MarioStateFireRightIdle(mario, location.X, location.Y);
        }

        public override void Right()
        {
        }

        public override void Jump()
        {
            mario.State = new MarioStateFireRightJump(mario, location.X, location.Y);
        }

        public override void Crouch()
        {
            mario.State = new MarioStateFireRightCrouch(mario, location.X, location.Y);
        }

        public override void Small()
        {
            mario.State = new MarioStateSmallRightRun(mario, location.X, location.Y);
        }

        public override void Big()
        {
            mario.State = new MarioStateBigRightRun(mario, location.X, location.Y);
        }

        public override void Fire()
        {
        }
    }

}
