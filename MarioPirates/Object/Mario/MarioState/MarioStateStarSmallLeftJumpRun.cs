namespace MarioPirates
{
    internal class MarioStateStarSmallLeftJumpRun : MarioStateStarSmall
    {
        public MarioStateStarSmallLeftJumpRun(Mario mario) : base(mario)
        {
            mario.Sprite = SpriteFactory.Instance.CreateSprite("star_small_jump_right");
        }

        public override void Left()
        {
        }

        public override void Right()
        {
            mario.State = new MarioStateStarSmallLeftJump(mario);
        }

        public override void Jump()
        {
        }

        public override void Crouch()
        {
            mario.State = new MarioStateStarSmallLeftRun(mario);
        }

        public override void Big()
        {
            mario.State = new MarioStateStarBigLeftJumpRun(mario);
        }

        public override void Fire()
        {
            mario.State = new MarioStateStarBigLeftJumpRun(mario);
        }
    }
}
