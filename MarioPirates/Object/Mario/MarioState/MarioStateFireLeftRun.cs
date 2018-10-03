namespace MarioPirates
{
    internal class MarioStateFireLeftRun : MarioStateFire
    {
        public MarioStateFireLeftRun(Mario mario) : base(mario)
        {
            mario.Sprite = SpriteFactory.Instance.CreateSpriteMario("fire_run_left");
        }

        public override void Left()
        {
        }

        public override void Right()
        {
            mario.State = new MarioStateFireLeftIdle(mario);
        }

        public override void Jump()
        {
            mario.State = new MarioStateFireLeftJumpRun(mario);
        }

        public override void Crouch()
        {
            mario.State = new MarioStateFireLeftCrouchRun(mario);
        }

        public override void Small()
        {
            mario.State = new MarioStateSmallLeftRun(mario);
        }

        public override void Big()
        {
            mario.State = new MarioStateBigLeftRun(mario);
        }

        public override void Star()
        {
            mario.State = new MarioStateStarBigLeftRun(mario);
        }
    }
}
