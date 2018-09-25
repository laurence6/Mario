namespace MarioPirates
{

    public class MarioStateBigLeftCrouch : MarioStateBig
    {
        public MarioStateBigLeftCrouch(Mario mario, int dstX, int dstY) : base(mario, dstX, dstY)
        {
            mario.State = SpriteFactory.Instance.CreateSprite("mario_big_crouch_left");
        }

        public override void Jump()
        {
            mario.State = new MarioStateBigLeftIdle(mario, location.X, location.Y);
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
        }

        public override void Fire()
        {
            mario.State = new MarioStateFireLeftCrouch(mario, location.X, location.Y);
        }
    }

}
