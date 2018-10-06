namespace MarioPirates
{
    internal class MarioStateStarBigLeftCrouchRun : MarioStateStarBig
    {
        public MarioStateStarBigLeftCrouchRun(Mario mario) : base(mario)
        {
            mario.Sprite = SpriteFactory.CreateSprite("star_big_crouch_left");
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
