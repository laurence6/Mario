namespace MarioPirates
{
    internal class MarioStateStarBigLeftJump : MarioStateStarBig
    {
        public MarioStateStarBigLeftJump(Mario mario) : base(mario)
        {
            mario.Sprite = SpriteFactory.CreateSpriteMario("star_big_jump_right");
        }

        public override void Left()
        {
            mario.State = new MarioStateStarBigLeftJumpRun(mario);
        }

        public override void Right()
        {
            mario.State = new MarioStateStarBigRightJumpRun(mario);
        }

        public override void Jump()
        {
        }

        public override void Crouch()
        {
            mario.State = new MarioStateStarBigLeftIdle(mario);
        }
    }
}
