namespace MarioPirates
{
    internal class MarioStateStarBigLeftCrouch : MarioStateStarBig
    {
        public MarioStateStarBigLeftCrouch(Mario mario) : base(mario)
        {
            mario.Sprite = SpriteFactory.CreateSpriteMario("star_big_crouch_right");
        }

        public override void Left()
        {
            mario.State = new MarioStateStarBigLeftCrouchRun(mario);
        }

        public override void Right()
        {
            mario.State = new MarioStateStarBigRightCrouchRun(mario);
        }

        public override void Jump()
        {
            mario.State = new MarioStateStarBigLeftIdle(mario);
        }

        public override void Crouch()
        {
        }
    }
}
