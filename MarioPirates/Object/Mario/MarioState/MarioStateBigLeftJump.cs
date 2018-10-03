namespace MarioPirates
{
    internal class MarioStateBigLeftJump : MarioStateBig
    {
        public MarioStateBigLeftJump(Mario mario) : base(mario)
        {
            mario.Sprite = SpriteFactory.Instance.CreateSpriteMario("big_jump_left");
        }

        public override void Left()
        {
            mario.State = new MarioStateBigLeftJumpRun(mario);
        }

        public override void Right()
        {
            mario.State = new MarioStateBigRightJumpRun(mario);
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

        public override void Fire()
        {
            mario.State = new MarioStateFireLeftJump(mario);
        }

        public override void Star()
        {
            mario.State = new MarioStateStarBigLeftJump(mario);
        }
    }
}
