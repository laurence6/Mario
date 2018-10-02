namespace MarioPirates
{
    internal class MarioStateBigRightJumpRun : MarioStateBig
    {
        public MarioStateBigRightJumpRun(Mario mario) : base(mario)
        {
            mario.Sprite = SpriteFactory.CreateSpriteMario("big_jump_right");
        }

        public override void Left()
        {
            mario.State = new MarioStateBigRightJump(mario);
        }

        public override void Right()
        {
        }

        public override void Jump()
        {
        }

        public override void Crouch()
        {
            mario.State = new MarioStateBigRightRun(mario);
        }

        public override void Small()
        {
            mario.State = new MarioStateSmallRightJumpRun(mario);
        }

        public override void Fire()
        {
            mario.State = new MarioStateFireRightJumpRun(mario);
        }

        public override void Star()
        {
            mario.State = new MarioStateStarBigRightJumpRun(mario);
        }
    }
}
