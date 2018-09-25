namespace MarioPirates
{

    public class MarioStateSmallLeftJump : MarioStateSmall
    {
        public MarioStateSmallLeftJump(Mario mario, int dstX, int dstY) : base(mario, dstX, dstY)
        {
            mario.State = SpriteFactory.Instance.CreateSprite("mario_small_jump_left");
        }

        public override void Jump()
        {
        }

        public override void Crouch()
        {
            mario.State = new MarioStateSmallLeftIdle(mario, location.X, location.Y);
        }

        public override void Small()
        {
        }

        public override void Big()
        {
            mario.State = new MarioStateBigLeftJump(mario, location.X, location.Y);
        }

        public override void Fire()
        {
            mario.State = new MarioStateFireLeftJump(mario, location.X, location.Y);
        }

        public override void Update()
        {
            mario.DrawSrc.X = 30;
            mario.DrawSrc.Y = 0;
            base.Update();
        }
    }

}
