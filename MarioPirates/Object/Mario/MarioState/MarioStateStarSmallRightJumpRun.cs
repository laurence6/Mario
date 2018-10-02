namespace MarioPirates
{
    internal class MarioStateStarSmallRightJumpRun : MarioStateStarSmall
    {
        public MarioStateStarSmallRightJumpRun(Mario mario) : base(mario)
        {
            mario.Sprite = SpriteFactory.CreateSpriteMario("star_small_jump_right");
        }

        public override void Left()
        {
            mario.State = new MarioStateStarSmallRightJump(mario);
        }

        public override void Right()
        {
        }

        public override void Jump()
        {
        }

        public override void Crouch()
        {
            mario.State = new MarioStateStarSmallRightRun(mario);
        }

        public override void Big()
        {
            mario.State = new MarioStateStarBigRightJumpRun(mario);
        }

        public override void Fire()
        {
            mario.State = new MarioStateStarBigRightJumpRun(mario);
        }
    }
}
