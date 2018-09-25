namespace MarioPirates
{
    internal class MarioStateSmallRightIdle : MarioStateSmall
    {
        public MarioStateSmallRightIdle(Mario mario) : base(mario)
        {
            mario.sprite = SpriteFactory.Instance.CreateSprite("mario_small_idle_right");
        }

        public override void Left()
        {
            mario.State = new MarioStateSmallLeftIdle(mario);
        }

        public override void Right()
        {
            mario.State = new MarioStateSmallRightRun(mario);
        }

        public override void Jump()
        {
            mario.State = new MarioStateSmallRightJump(mario);
        }

        public override void Crouch()
        {
            mario.State = new MarioStateSmallRightCrouch(mario);
        }

        public override void Small()
        {
        }

        public override void Big()
        {
            mario.State = new MarioStateBigRightIdle(mario);
        }

        public override void Fire()
        {
            mario.State = new MarioStateFireRightIdle(mario);
        }
    }

}
