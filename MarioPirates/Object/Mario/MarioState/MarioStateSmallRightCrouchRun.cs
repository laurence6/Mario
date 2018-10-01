namespace MarioPirates
{
    internal class MarioStateSmallRightCrouchRun : MarioStateSmall
    {
        public MarioStateSmallRightCrouchRun(Mario mario) : base(mario)
        {
            mario.Sprite = SpriteFactory.CreateSpriteMario("small_crouch_right");
        }

        public override void Left()
        {
            mario.State = new MarioStateSmallRightCrouch(mario);
        }

        public override void Right()
        {
        }

        public override void Jump()
        {
            mario.State = new MarioStateSmallRightRun(mario);
        }

        public override void Crouch()
        {
        }

        public override void Small()
        {
        }

        public override void Big()
        {
            mario.State = new MarioStateBigRightCrouchRun(mario);
        }

        public override void Fire()
        {
            mario.State = new MarioStateFireRightCrouchRun(mario);
        }
    }
}
