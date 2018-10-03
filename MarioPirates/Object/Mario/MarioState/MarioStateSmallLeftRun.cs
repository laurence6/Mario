namespace MarioPirates
{
    internal class MarioStateSmallLeftRun : MarioStateSmall
    {
        public MarioStateSmallLeftRun(Mario mario) : base(mario)
        {
            mario.Sprite = SpriteFactory.Instance.CreateSprite("small_run_left");
        }

        public override void Left()
        {
        }

        public override void Right()
        {
            mario.State = new MarioStateSmallLeftIdle(mario);
        }

        public override void Jump()
        {
            mario.State = new MarioStateSmallLeftJumpRun(mario);
        }

        public override void Crouch()
        {
            mario.State = new MarioStateSmallLeftCrouchRun(mario);
        }

        public override void Big()
        {
            mario.State = new MarioStateBigLeftRun(mario);
        }

        public override void Fire()
        {
            mario.State = new MarioStateFireLeftRun(mario);
        }

        public override void Star()
        {
            mario.State = new MarioStateStarSmallLeftRun(mario);
        }
    }
}
