namespace MarioPirates
{
    internal class MarioStateBigRightIdle : MarioStateBig
    {
        public MarioStateBigRightIdle(Mario mario) : base(mario)
        {
            mario.sprite = SpriteFactory.Instance.CreateSprite("mario_big_idle_right");
        }

        public override void Left()
        {
            mario.State = new MarioStateBigLeftIdle(mario);
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

        public override void Big()
        {
        }

        public override void Fire()
        {
            mario.State = new MarioStateFireRightIdle(mario);
        }
    }

}
