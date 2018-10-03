namespace MarioPirates
{
    internal class MarioStateBigLeftRun : MarioStateBig
    {
        public MarioStateBigLeftRun(Mario mario) : base(mario)
        {
            mario.Sprite = SpriteFactory.Instance.CreateSpriteMario("big_run_left");
        }

        public override void Left()
        {
        }

        public override void Right()
        {
            mario.State = new MarioStateBigLeftIdle(mario);
        }

        public override void Jump()
        {
            mario.State = new MarioStateBigLeftJumpRun(mario);
        }

        public override void Crouch()
        {
            mario.State = new MarioStateBigLeftCrouchRun(mario);
        }

        public override void Small()
        {
            mario.State = new MarioStateSmallLeftRun(mario);
        }

        public override void Fire()
        {
            mario.State = new MarioStateFireLeftRun(mario);
        }

        public override void Star()
        {
            mario.State = new MarioStateStarBigLeftRun(mario);
        }
    }
}
