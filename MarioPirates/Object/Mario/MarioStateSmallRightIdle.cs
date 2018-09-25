namespace MarioPirates
{

    public class MarioStateSmallRightIdle : MarioStateSmall
    {
        public MarioStateSmallRightIdle(Mario mario, int dstX, int dstY) : base(mario, dstX, dstY)
        {
            mario.State = SpriteFactory.Instance.CreateSprite("mario_small_idle_right");
        }

        public override void Left()
        {
            mario.State = new MarioStateSmallLeftIdle(mario, location.X, location.Y);
        }

        public override void Right()
        {
            mario.State = new MarioStateSmallRightRun(mario, location.X, location.Y);
        }

        public override void Jump()
        {
            mario.State = new MarioStateSmallRightJump(mario, location.X, location.Y);
        }

        public override void Crouch()
        {
            mario.State = new MarioStateSmallRightCrouch(mario, location.X, location.Y);
        }

        public override void Small()
        {
        }

        public override void Big()
        {
            mario.State = new MarioStateBigRightIdle(mario, location.X, location.Y);
        }

        public override void Fire()
        {
            mario.State = new MarioStateFireRightIdle(mario, location.X, location.Y);
        }

        public override void Update()
        {
            mario.DrawSrc.X = 180;
            mario.DrawSrc.Y = 0;
            base.Update();
        }
    }

}
