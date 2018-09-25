namespace MarioPirates
{
    internal class MarioStateSmallLeftCrouch : MarioStateSmall
    {
        public MarioStateSmallLeftCrouch(Mario mario) : base(mario)
        {
            mario.Sprite = SpriteFactory.Instance.CreateSprite("mario_small_crouch_left");
        }

        public override void Jump()
        {
            mario.State = new MarioStateSmallLeftIdle(mario);
        }

        public override void Crouch()
        {
        }

        public override void Small()
        {
        }

        public override void Big()
        {
            mario.State = new MarioStateBigLeftCrouch(mario);
        }

        public override void Fire()
        {
            mario.State = new MarioStateFireLeftCrouch(mario);
        }
    }

}
