namespace MarioPirates
{
    internal class MarioStateStarBigLeftRun : MarioStateStarBig
    {
        public MarioStateStarBigLeftRun(Mario mario) : base(mario)
        {
            mario.Sprite = SpriteFactory.CreateSpriteMario("star_big_idle_right");
        }

        public override void Left()
        {
        }

        public override void Right()
        {
            mario.State = new MarioStateStarBigLeftIdle(mario);
        }

        public override void Jump()
        {
            mario.State = new MarioStateStarBigLeftJumpRun(mario);
        }

        public override void Crouch()
        {
            mario.State = new MarioStateStarBigLeftCrouchRun(mario);
        }
    }
}
