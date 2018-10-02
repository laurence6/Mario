namespace MarioPirates
{
    internal class MarioStateStarSmallRightRun : MarioStateStarSmall
    {
        public MarioStateStarSmallRightRun(Mario mario) : base(mario)
        {
            mario.Sprite = SpriteFactory.CreateSpriteMario("star_small_run_right");
        }

        public override void Left()
        {
            mario.State = new MarioStateStarSmallRightIdle(mario);
        }

        public override void Right()
        {
        }

        public override void Jump()
        {
            mario.State = new MarioStateStarSmallRightJumpRun(mario);
        }

        public override void Crouch()
        {
            mario.State = new MarioStateStarSmallRightCrouchRun(mario);
        }

        public override void Big()
        {
            mario.State = new MarioStateStarBigRightRun(mario);
        }

        public override void Fire()
        {
            mario.State = new MarioStateStarBigRightRun(mario);
        }
    }
}
