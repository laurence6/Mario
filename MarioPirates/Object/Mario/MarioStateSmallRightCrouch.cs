namespace MarioPirates
{

    public class MarioStateSmallRightCrouch : MarioStateSmall
    {
        public MarioStateSmallRightCrouch(Mario mario, int dstX, int dstY) : base(mario, dstX, dstY)
        {
            mario.State = SpriteFactory.Instance.CreateSprite("mario_small_crouch_right");
        }

        public override void Jump()
        {
            mario.State = new MarioStateSmallRightIdle(mario, location.X, location.Y);
        }

        public override void Crouch()
        {
        }

        public override void Small()
        {
        }

        public override void Big()
        {
            mario.State = new MarioStateBigRightCrouch(mario, location.X, location.Y);
        }

        public override void Fire()
        {
            mario.State = new MarioStateFireRightCrouch(mario, location.X, location.Y);
        }
    }

}
