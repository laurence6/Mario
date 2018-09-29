namespace MarioPirates
{
    internal class MarioStateSmallLeftJump : MarioStateSmall
    {
        public MarioStateSmallLeftJump(Mario mario) : base(mario)
        {
            mario.Sprite = SpriteFactory.CreateSpriteMario("small_jump_left");
        }

        public override void Jump()
        {
        }

        public override void Crouch()
        {
            mario.State = new MarioStateSmallLeftIdle(mario);
        }

        public override void Small()
        {
        }

        public override void Big()
        {
            mario.State = new MarioStateBigLeftJump(mario);
        }

        public override void Fire()
        {
            mario.State = new MarioStateFireLeftJump(mario);
        }
    }
}
