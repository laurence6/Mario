namespace MarioPirates
{
    internal class MarioStateSmallRightJump : MarioStateSmall
    {
        public MarioStateSmallRightJump(Mario mario) : base(mario)
        {
            mario.Sprite = SpriteFactory.Instance.CreateSpriteMario("small_jump_right");
        }

        public override void Jump()
        {
        }

        public override void Crouch()
        {
            mario.State = new MarioStateSmallRightIdle(mario);
        }

        public override void Small()
        {
        }

        public override void Big()
        {
            mario.State = new MarioStateBigRightJump(mario);
        }

        public override void Fire()
        {
            mario.State = new MarioStateFireRightJump(mario);
        }
    }
}
