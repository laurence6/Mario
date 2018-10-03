namespace MarioPirates
{
    internal class MarioStateStarSmallLeftRun : MarioStateStarSmall
    {
        public MarioStateStarSmallLeftRun(Mario mario) : base(mario)
        {
            mario.Sprite = SpriteFactory.Instance.CreateSpriteMario("star_small_idle_right");
        }

        public override void Left()
        {
        }

        public override void Right()
        {
            mario.State = new MarioStateStarSmallLeftIdle(mario);
        }

        public override void Jump()
        {
            mario.State = new MarioStateStarSmallLeftJumpRun(mario);
        }

        public override void Crouch()
        {
            mario.State = new MarioStateStarSmallLeftCrouchRun(mario);
        }

        public override void Big()
        {
            mario.State = new MarioStateStarBigLeftRun(mario);
        }

        public override void Fire()
        {
            mario.State = new MarioStateStarBigLeftRun(mario);
        }
    }
}
