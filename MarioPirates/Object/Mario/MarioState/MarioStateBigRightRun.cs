namespace MarioPirates
{
    internal class MarioStateBigRightRun : MarioStateBig
    {
        public MarioStateBigRightRun(Mario mario) : base(mario)
        {
            mario.Sprite = SpriteFactory.CreateSpriteMario("big_run_right");
        }

        public override void Left()
        {
            mario.State = new MarioStateBigRightIdle(mario);
        }

        public override void Right()
        {
        }

        public override void Jump()
        {
            mario.State = new MarioStateBigRightJumpRun(mario);
        }

        public override void Crouch()
        {
            mario.State = new MarioStateBigRightCrouchRun(mario);
        }

        public override void Small()
        {
            mario.State = new MarioStateSmallRightRun(mario);
        }

        public override void Fire()
        {
            mario.State = new MarioStateFireRightRun(mario);
        }

        public override void Star()
        {
            mario.State = new MarioStateStarBigRightRun(mario);
        }
    }
}
