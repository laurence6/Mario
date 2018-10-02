namespace MarioPirates
{
    internal class MarioStateFireRightJumpRun : MarioStateFire
    {
        public MarioStateFireRightJumpRun(Mario mario) : base(mario)
        {
            mario.Sprite = SpriteFactory.CreateSpriteMario("fire_jump_right");
        }

        public override void Left()
        {
            mario.State = new MarioStateFireRightJump(mario);
        }

        public override void Right()
        {
        }

        public override void Jump()
        {
        }

        public override void Crouch()
        {
            mario.State = new MarioStateFireRightRun(mario);
        }

        public override void Small()
        {
            mario.State = new MarioStateSmallRightJumpRun(mario);
        }

        public override void Big()
        {
            mario.State = new MarioStateBigRightJumpRun(mario);
        }

        public override void Star()
        {
            mario.State = new MarioStateStarBigRightJumpRun(mario);
        }
    }
}
