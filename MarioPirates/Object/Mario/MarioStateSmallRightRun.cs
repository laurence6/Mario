namespace MarioPirates
{
    internal class MarioStateSmallRightRun : MarioStateSmall
    {
        public MarioStateSmallRightRun(Mario mario) : base(mario)
        {
            mario.Sprite = SpriteFactory.CreateSpriteMario("small_run_right");
        }

        public override void Left()
        {
            mario.State = new MarioStateSmallRightIdle(mario);
        }

        public override void Right()
        {
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
            mario.State = new MarioStateBigRightRun(mario);
        }

        public override void Fire()
        {
            mario.State = new MarioStateFireRightRun(mario);
        }
    }
}
