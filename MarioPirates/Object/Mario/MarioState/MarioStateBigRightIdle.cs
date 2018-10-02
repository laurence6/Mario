namespace MarioPirates
{
    internal class MarioStateBigRightIdle : MarioStateBig
    {
        public MarioStateBigRightIdle(Mario mario) : base(mario)
        {
            mario.Sprite = SpriteFactory.CreateSpriteMario("big_idle_right");
        }

        public override void Left()
        {
            mario.State = new MarioStateBigLeftRun(mario);
        }

        public override void Right()
        {
            mario.State = new MarioStateBigRightRun(mario);
        }

        public override void Jump()
        {
            mario.State = new MarioStateBigRightJump(mario);
        }

        public override void Crouch()
        {
            mario.State = new MarioStateBigRightCrouch(mario);
        }

        public override void Small()
        {
            mario.State = new MarioStateSmallRightIdle(mario);
        }

        public override void Fire()
        {
            mario.State = new MarioStateFireRightIdle(mario);
        }

        public override void Star()
        {
            mario.State = new MarioStateStarBigRightIdle(mario);
        }
    }
}
