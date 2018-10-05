namespace MarioPirates
{
    internal class MarioStateStarBigLeftJumpRun : MarioStateStarBig
    {
        public MarioStateStarBigLeftJumpRun(Mario mario) : base(mario)
        {
            mario.Sprite = SpriteFactory.Instance.CreateSprite("star_big_jump_left");
        }

        public override void Left()
        {
        }

        public override void Right()
        {
            mario.State = new MarioStateStarBigLeftJump(mario);
        }

        public override void Jump()
        {
        }

        public override void Crouch()
        {
            mario.State = new MarioStateStarBigLeftRun(mario);
        }
    }
}
