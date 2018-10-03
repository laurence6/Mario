namespace MarioPirates
{
    internal class MarioStateStarSmallLeftCrouchRun : MarioStateStarSmall
    {
        public MarioStateStarSmallLeftCrouchRun(Mario mario) : base(mario)
        {
            mario.Sprite = SpriteFactory.Instance.CreateSprite("star_small_crouch_right");
        }

        public override void Left()
        {
        }

        public override void Right()
        {
            mario.State = new MarioStateStarSmallLeftCrouch(mario);
        }

        public override void Jump()
        {
            mario.State = new MarioStateStarSmallLeftRun(mario);
        }

        public override void Crouch()
        {
        }

        public override void Big()
        {
            mario.State = new MarioStateStarBigLeftCrouchRun(mario);
        }

        public override void Fire()
        {
            mario.State = new MarioStateStarBigLeftCrouchRun(mario);
        }
    }
}
