namespace MarioPirates
{
    internal class MarioStateStarBigRightJumpRun : MarioStateStarBig
    {
        public MarioStateStarBigRightJumpRun(Mario mario) : base(mario)
        {
            mario.Sprite = SpriteFactory.Instance.CreateSpriteMario("star_big_jump_right");
        }

        public override void Left()
        {
            mario.State = new MarioStateStarBigRightJump(mario);
        }

        public override void Right()
        {
        }

        public override void Jump()
        {
        }

        public override void Crouch()
        {
            mario.State = new MarioStateStarBigRightRun(mario);
        }
    }
}
