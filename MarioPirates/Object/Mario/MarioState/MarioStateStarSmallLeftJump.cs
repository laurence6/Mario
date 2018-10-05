namespace MarioPirates
{
    internal class MarioStateStarSmallLeftJump : MarioStateStarSmall
    {
        public MarioStateStarSmallLeftJump(Mario mario) : base(mario)
        {
            mario.Sprite = SpriteFactory.Instance.CreateSprite("star_small_jump_left");
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
            mario.State = new MarioStateStarSmallLeftIdle(mario);
        }

        public override void Big()
        {
            mario.State = new MarioStateStarBigLeftJump(mario);
        }

        public override void Fire()
        {
            mario.State = new MarioStateStarBigLeftJump(mario);
        }
    }
}
