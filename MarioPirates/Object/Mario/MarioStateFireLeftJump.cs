namespace MarioPirates
{

    public class MarioStateFireLeftJump : MarioStateFire
    {
        public MarioStateFireLeftJump(Mario mario, int dstX, int dstY) : base(mario, dstX, dstY)
        {
            mario.State = SpriteFactory.Instance.CreateSprite("mario_fire_jump_left");
        }

        public override void Jump()
        {
        }

        public override void Crouch()
        {
            mario.State = new MarioStateFireLeftIdle(mario, location.X, location.Y);
        }

        public override void Small()
        {
            mario.State = new MarioStateSmallLeftJump(mario, location.X, location.Y);
        }

        public override void Big()
        {
            mario.State = new MarioStateBigLeftJump(mario, location.X, location.Y);
        }

        public override void Fire()
        {
        }
    }

}
