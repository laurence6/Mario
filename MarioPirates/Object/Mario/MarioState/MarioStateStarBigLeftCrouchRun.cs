namespace MarioPirates
{
    internal class MarioStateStarBigLeftCrouchRun : MarioStateStarBig
    {
        public MarioStateStarBigLeftCrouchRun(Mario mario) : base(mario)
        {
            mario.Sprite = SpriteFactory.Instance.CreateSprite("star_big_crouch_right");
        }

        public override void Left()
        {
        }

        public override void Right()
        {
            mario.State = new MarioStateStarBigLeftCrouch(mario);
        }

        public override void Jump()
        {
            mario.State = new MarioStateStarBigLeftRun(mario);
        }

        public override void Crouch()
        {
        }
    }
}
