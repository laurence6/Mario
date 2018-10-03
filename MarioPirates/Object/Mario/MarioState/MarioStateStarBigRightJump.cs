namespace MarioPirates
{
    internal class MarioStateStarBigRightJump : MarioStateStarBig
    {
        public MarioStateStarBigRightJump(Mario mario) : base(mario)
        {
            mario.Sprite = SpriteFactory.Instance.CreateSprite("star_big_jump_right");
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
            mario.State = new MarioStateStarBigRightIdle(mario);
        }
    }
}
