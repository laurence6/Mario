namespace MarioPirates
{
    internal class MarioStateSmallRightJumpRun : MarioStateSmall
    {
        public MarioStateSmallRightJumpRun(Mario mario) : base(mario)
        {
            mario.Sprite = SpriteFactory.CreateSpriteMario("small_jump_right");
        }

        public override void Left()
        {
            mario.State = new MarioStateSmallRightJump(mario);
        }

        public override void Right()
        {
        }

        public override void Jump()
        {
        }

        public override void Crouch()
        {
            mario.State = new MarioStateSmallRightRun(mario);
        }

        public override void Small()
        {
        }

        public override void Big()
        {
            mario.State = new MarioStateBigRightJumpRun(mario);
        }

        public override void Fire()
        {
            mario.State = new MarioStateFireRightJumpRun(mario);
        }
    }
}