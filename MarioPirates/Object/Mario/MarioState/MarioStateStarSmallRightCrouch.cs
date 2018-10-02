namespace MarioPirates
{
    internal class MarioStateStarSmallRightCrouch : MarioStateStarSmall
    {
        public MarioStateStarSmallRightCrouch(Mario mario) : base(mario)
        {
            mario.Sprite = SpriteFactory.CreateSpriteMario("star_small_crouch_right");
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
            mario.State = new MarioStateStarSmallRightIdle(mario);
        }

        public override void Crouch()
        {
        }

        public override void Big()
        {
            mario.State = new MarioStateStarBigRightCrouch(mario);
        }

        public override void Fire()
        {
            mario.State = new MarioStateStarBigRightCrouch(mario);
        }
    }
}
