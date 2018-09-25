namespace MarioPirates
{

    public class MarioStateFireRightJump : MarioStateFire
    {
        public MarioStateFireRightJump(Mario mario, int dstX, int dstY) : base(mario, dstX, dstY)
        {
                mario.State = SpriteFactory.Instance.CreateSprite("mario_fire_jump_right");
        }

        public override void Jump()
        {
        }

        public override void Crouch()
        {
            mario.State = new MarioStateFireRightIdle(mario, location.X, location.Y);
        }

        public override void Small()
        {
            mario.State = new MarioStateSmallRightJump(mario, location.X, location.Y);
        }

        public override void Big()
        {
            mario.State = new MarioStateBigRightJump(mario, location.X, location.Y);
        }

        public override void Fire()
        {
        }
    }

}
