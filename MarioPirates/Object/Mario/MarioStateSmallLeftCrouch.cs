namespace MarioPirates
{

    public class MarioStateSmallLeftCrouch : MarioStateSmall
    {
        public MarioStateSmallLeftCrouch(Mario mario, int dstX, int dstY) : base(mario, dstX, dstY)
        {
            mario.State = SpriteFactory.Instance.CreateSprite("mario_small_crouch_left");
        }

        public override void Jump()
        {
            mario.State = new MarioStateSmallLeftIdle(mario, location.X, location.Y);
        }

        public override void Crouch()
        {
        }

        public override void Small()
        {
        }

        public override void Big()
        {
            mario.State = new MarioStateBigLeftCrouch(mario, location.X, location.Y);
        }

        public override void Fire()
        {
            mario.State = new MarioStateFireLeftCrouch(mario, location.X, location.Y);
        }

        public override void Update()
        {
            mario.DrawSrc.X = 0;
            mario.DrawSrc.Y = 0;
            base.Update();
        }
    }

}
