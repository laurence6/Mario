namespace MarioPirates
{
    internal class MarioStateStarSmallRightJump : MarioStateStarSmall
    {
        public MarioStateStarSmallRightJump(Mario mario) : base(mario)
        {
            mario.Sprite = SpriteFactory.CreateSprite("star_small_jump_right");
        }

        public override void Left()
        {
            mario.State = new MarioStateStarSmallLeftJumpRun(mario);
        }

        public override void Right()
        {
            mario.State = new MarioStateStarSmallRightJumpRun(mario);
        }

        public override void Jump()
        {
        }

        public override void Crouch()
        {
            mario.State = new MarioStateStarSmallRightIdle(mario);
        }

        public override void Big()
        {
            mario.State = new MarioStateStarBigRightJump(mario);
        }

        public override void Fire()
        {
            mario.State = new MarioStateStarBigRightJump(mario);
        }
    }
}
