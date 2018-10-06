namespace MarioPirates
{
    internal class MarioStateSmallRightRun : MarioStateSmall
    {
        public MarioStateSmallRightRun(Mario mario) : base(mario)
        {
            mario.Sprite = SpriteFactory.CreateSprite("small_run_right");
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
            mario.State = new MarioStateSmallRightJumpRun(mario);
        }

        public override void Crouch()
        {
            mario.State = new MarioStateSmallRightCrouchRun(mario);
        }

        public override void Big()
        {
            mario.State = new MarioStateBigRightRun(mario);
        }

        public override void Fire()
        {
            mario.State = new MarioStateFireRightRun(mario);
        }

        public override void Star()
        {
            mario.State = new MarioStateStarSmallRightRun(mario);
        }
    }
}
