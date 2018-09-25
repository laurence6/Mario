namespace MarioPirates
{
    internal class MarioStateSmallRightCrouch : MarioStateSmall
    {
        public MarioStateSmallRightCrouch(Mario mario) : base(mario)
        {
            mario.sprite = SpriteFactory.Instance.CreateSprite("mario_small_crouch_right");
        }

        public override void Jump()
        {
            mario.State = new MarioStateSmallRightIdle(mario);
        }

        public override void Crouch()
        {
        }

        public override void Small()
        {
        }

        public override void Big()
        {
            mario.State = new MarioStateBigRightCrouch(mario);
        }

        public override void Fire()
        {
            mario.State = new MarioStateFireRightCrouch(mario);
        }
    }

}
