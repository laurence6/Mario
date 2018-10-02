namespace MarioPirates
{
    internal class MarioStateSmallRightJump : MarioStateSmall
    {
        public MarioStateSmallRightJump(Mario mario) : base(mario)
        {
            mario.Sprite = SpriteFactory.CreateSpriteMario("small_jump_right");
        }

        public override void Left()
        {
            mario.State = new MarioStateSmallLeftJumpRun(mario);
        }

        public override void Right()
        {
            mario.State = new MarioStateSmallRightJumpRun(mario);
        }

        public override void Jump()
        {
        }

        public override void Crouch()
        {
            mario.State = new MarioStateSmallRightIdle(mario);
        }

        public override void Small()
        {
        }

        public override void Big()
        {
            mario.State = new MarioStateBigRightJump(mario);
        }

        public override void Fire()
        {
            mario.State = new MarioStateFireRightJump(mario);
        }

        public override void Star()
        {
            mario.State = new MarioStateStarSmallRightJump(mario);
        }
    }
}
