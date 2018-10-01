namespace MarioPirates
{
    internal class MarioStateSmallLeftJumpRun : MarioStateSmall
    {
        public MarioStateSmallLeftJumpRun(Mario mario) : base(mario)
        {
            mario.Sprite = SpriteFactory.CreateSpriteMario("small_jump_left");
        }

        public override void Left()
        {
        }

        public override void Right()
        {
            mario.State = new MarioStateSmallLeftJump(mario);
        }

        public override void Jump()
        {
        }

        public override void Crouch()
        {
            mario.State = new MarioStateSmallLeftRun(mario);
        }

        public override void Small()
        {
        }

        public override void Big()
        {
            mario.State = new MarioStateBigLeftJumpRun(mario);
        }

        public override void Fire()
        {
            mario.State = new MarioStateFireLeftJumpRun(mario);
        }
    }
}
