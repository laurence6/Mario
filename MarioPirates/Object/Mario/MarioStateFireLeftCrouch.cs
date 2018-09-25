namespace MarioPirates
{

    public class MarioStateFireLeftCrouch : MarioStateFire
    {
        public MarioStateFireLeftCrouch(Mario mario, int dstX, int dstY) : base(mario, dstX, dstY)
        {
            mario.State = SpriteFactory.Instance.CreateSprite("mario_fire_crouch_left");
        }

        public override void Jump()
        {
            mario.State = new MarioStateFireLeftIdle(mario, location.X, location.Y);
        }

        public override void Crouch()
        {
        }

        public override void Small()
        {
            mario.State = new MarioStateSmallLeftCrouch(mario, location.X, location.Y);
        }

        public override void Big()
        {
            mario.State = new MarioStateBigLeftCrouch(mario, location.X, location.Y);
        }

        public override void Fire()
        {
        }

        public override void Update()
        {
            mario.DrawSrc.X = 0;
            mario.DrawSrc.Y = 0;
            base.Update();
        }
    }

}
