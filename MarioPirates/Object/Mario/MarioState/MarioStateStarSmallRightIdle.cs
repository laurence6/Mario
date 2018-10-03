namespace MarioPirates
{
    internal class MarioStateStarSmallRightIdle : MarioStateStarSmall
    {
        public MarioStateStarSmallRightIdle(Mario mario) : base(mario)
        {
            mario.Sprite = SpriteFactory.Instance.CreateSpriteMario("star_small_idle_right");
        }

        public override void Left()
        {
            mario.State = new MarioStateStarSmallLeftRun(mario);
        }

        public override void Right()
        {
            mario.State = new MarioStateStarSmallRightRun(mario);
        }

        public override void Jump()
        {
            mario.State = new MarioStateStarSmallRightJump(mario);
        }

        public override void Crouch()
        {
            mario.State = new MarioStateStarSmallRightCrouch(mario);
        }

        public override void Big()
        {
            mario.State = new MarioStateStarBigRightIdle(mario);
        }

        public override void Fire()
        {
            mario.State = new MarioStateStarBigRightIdle(mario);
        }
    }
}
