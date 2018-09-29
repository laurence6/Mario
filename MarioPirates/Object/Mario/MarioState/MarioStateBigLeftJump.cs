namespace MarioPirates
{
    internal class MarioStateBigLeftJump : MarioStateBig
    {
        public MarioStateBigLeftJump(Mario mario) : base(mario)
        {
            mario.Sprite = SpriteFactory.CreateSpriteMario("big_jump_left");
        }

        public override void Jump()
        {
        }

        public override void Crouch()
        {
            mario.State = new MarioStateBigLeftIdle(mario);
        }

        public override void Small()
        {
            mario.State = new MarioStateSmallLeftJump(mario);
        }

        public override void Big()
        {
        }

        public override void Fire()
        {
            mario.State = new MarioStateFireLeftJump(mario);
        }
    }
}
