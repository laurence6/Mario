namespace MarioPirates
{
    internal class MarioStateStarBigRightCrouchRun : MarioStateStarBig
    {
        public MarioStateStarBigRightCrouchRun(Mario mario) : base(mario)
        {
            mario.Sprite = SpriteFactory.Instance.CreateSpriteMario("star_big_crouch_right");
        }

        public override void Left()
        {
            mario.State = new MarioStateStarBigRightCrouch(mario);
        }

        public override void Right()
        {
        }

        public override void Jump()
        {
            mario.State = new MarioStateStarBigRightRun(mario);
        }

        public override void Crouch()
        {
        }
    }
}
