namespace MarioPirates
{
    internal class MarioStateStarBigRightRun : MarioStateStarBig
    {
        public MarioStateStarBigRightRun(Mario mario) : base(mario)
        {
            mario.Sprite = SpriteFactory.CreateSprite("star_big_run_right");
        }

        public override void Left()
        {
            mario.State = new MarioStateStarBigRightIdle(mario);
        }

        public override void Right()
        {
        }

        public override void Jump()
        {
            mario.State = new MarioStateStarBigRightJumpRun(mario);
        }

        public override void Crouch()
        {
            mario.State = new MarioStateStarBigRightCrouchRun(mario);
        }
    }
}
