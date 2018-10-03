namespace MarioPirates
{
    internal class MarioStateStarSmallRightCrouchRun : MarioStateStarSmall
    {
        public MarioStateStarSmallRightCrouchRun(Mario mario) : base(mario)
        {
            mario.Sprite = SpriteFactory.Instance.CreateSpriteMario("star_small_crouch_right");
        }

        public override void Left()
        {
            mario.State = new MarioStateStarSmallRightCrouch(mario);
        }

        public override void Right()
        {
        }

        public override void Jump()
        {
            mario.State = new MarioStateStarSmallRightRun(mario);
        }

        public override void Crouch()
        {
        }

        public override void Big()
        {
            mario.State = new MarioStateStarBigRightCrouchRun(mario);
        }

        public override void Fire()
        {
            mario.State = new MarioStateStarBigRightCrouchRun(mario);
        }
    }
}
