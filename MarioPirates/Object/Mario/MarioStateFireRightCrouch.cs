namespace MarioPirates
{

    public class MarioStateFireRightCrouch : MarioStateFire
    {
        public MarioStateFireRightCrouch(Mario mario, int dstX, int dstY) : base(mario, dstX, dstY)
        {
            mario.State = SpriteFactory.Instance.CreateSprite("mario_fire_crouch_right");
        }

        public override void Jump()
        {
            mario.State = new MarioStateFireRightIdle(mario, location.X, location.Y);
        }

        public override void Crouch()
        {
        }

        public override void Small()
        {
            mario.State = new MarioStateSmallRightCrouch(mario, location.X, location.Y);
        }

        public override void Big()
        {
            mario.State = new MarioStateBigRightCrouch(mario, location.X, location.Y);
        }

        public override void Fire()
        {
        }
    }

}
