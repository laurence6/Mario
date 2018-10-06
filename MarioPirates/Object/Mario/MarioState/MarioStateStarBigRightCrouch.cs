namespace MarioPirates
{
    internal class MarioStateStarBigRightCrouch : MarioStateStarBig
    {
        public MarioStateStarBigRightCrouch(Mario mario) : base(mario)
        {
            mario.Sprite = SpriteFactory.CreateSprite("star_big_crouch_right");
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
            mario.State = new MarioStateStarBigRightIdle(mario);
        }

        public override void Crouch()
        {
        }
    }
}
