namespace MarioPirates
{
    internal class MarioStateBigRightJump : MarioStateBig
    {
        public MarioStateBigRightJump(Mario mario) : base(mario)
        {
            mario.Sprite = SpriteFactory.CreateSprite("big_jump_right");
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
            mario.State = new MarioStateBigRightIdle(mario);
        }

        public override void Small()
        {
            mario.State = new MarioStateSmallRightJump(mario);
        }

        public override void Fire()
        {
            mario.State = new MarioStateFireRightJump(mario);
        }

        public override void Star()
        {
            mario.State = new MarioStateStarBigRightJump(mario);
        }
    }
}
