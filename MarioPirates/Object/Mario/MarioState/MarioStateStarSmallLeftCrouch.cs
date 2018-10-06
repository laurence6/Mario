namespace MarioPirates
{
    internal class MarioStateStarSmallLeftCrouch : MarioStateStarSmall
    {
        public MarioStateStarSmallLeftCrouch(Mario mario) : base(mario)
        {
            mario.Sprite = SpriteFactory.CreateSprite("star_small_crouch_left");
        }

        public override void Left()
        {
            mario.State = new MarioStateStarSmallLeftCrouchRun(mario);
        }

        public override void Right()
        {
            mario.State = new MarioStateStarSmallRightCrouchRun(mario);
        }

        public override void Jump()
        {
            mario.State = new MarioStateStarSmallLeftIdle(mario);
        }

        public override void Crouch()
        {
        }

        public override void Big()
        {
            mario.State = new MarioStateStarBigLeftCrouch(mario);
        }

        public override void Fire()
        {
            mario.State = new MarioStateStarBigLeftCrouch(mario);
        }
    }
}
