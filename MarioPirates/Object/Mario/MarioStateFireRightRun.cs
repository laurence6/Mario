namespace MarioPirates
{
    internal class MarioStateFireRightRun : MarioStateFire
    {
        public MarioStateFireRightRun(Mario mario) : base(mario)
        {
            mario.Sprite = SpriteFactory.CreateSpriteMario("fire_run_right");
        }

        public override void Left()
        {
            mario.State = new MarioStateFireRightIdle(mario);
        }

        public override void Right()
        {
        }

        public override void Jump()
        {
            mario.State = new MarioStateFireRightJump(mario);
        }

        public override void Crouch()
        {
            mario.State = new MarioStateFireRightCrouch(mario);
        }

        public override void Small()
        {
            mario.State = new MarioStateSmallRightRun(mario);
        }

        public override void Big()
        {
            mario.State = new MarioStateBigRightRun(mario);
        }

        public override void Fire()
        {
        }
    }
}
