namespace MarioPirates
{

    public class MarioStateFireLeftIdle : MarioStateFire
    {
        public MarioStateFireLeftIdle(Mario mario, int dstX, int dstY) : base(mario, dstX, dstY)
        {
            mario.State = SpriteFactory.Instance.CreateSprite("mario_fire_idle_left");
        }

        public override void Left()
        {
            mario.State = new MarioStateFireLeftRun(mario, location.X, location.Y);
        }

        public override void Right()
        {
            mario.State = new MarioStateFireRightIdle(mario, location.X, location.Y);
        }

        public override void Jump()
        {
            mario.State = new MarioStateFireLeftJump(mario, location.X, location.Y);
        }

        public override void Crouch()
        {
            mario.State = new MarioStateFireLeftCrouch(mario, location.X, location.Y);
        }

        public override void Small()
        {
            mario.State = new MarioStateSmallLeftIdle(mario, location.X, location.Y);
        }

        public override void Big()
        {
            mario.State = new MarioStateBigLeftIdle(mario, location.X, location.Y);
        }

        public override void Fire()
        {
        }

        public override void Update()
        {
            mario.DrawSrc.X = 150;
            mario.DrawSrc.Y = 0;
            base.Update();
        }
    }

}
