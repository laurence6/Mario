namespace MarioPirates
{
    internal class MarioStateFireRightJump : MarioStateFire
    {
        public MarioStateFireRightJump(Mario mario) : base(mario)
        {
            mario.Sprite = SpriteFactory.Instance.CreateSprite("mario_fire_jump_right");
        }

        public override void Jump()
        {
        }

        public override void Crouch()
        {
            mario.State = new MarioStateFireRightIdle(mario);
        }

        public override void Small()
        {
            mario.State = new MarioStateSmallRightJump(mario);
        }

        public override void Big()
        {
            mario.State = new MarioStateBigRightJump(mario);
        }

        public override void Fire()
        {
        }
    }

}
