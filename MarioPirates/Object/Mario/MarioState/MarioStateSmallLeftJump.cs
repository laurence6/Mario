namespace MarioPirates
{
    internal class MarioStateSmallLeftJump : MarioStateSmall
    {
        public MarioStateSmallLeftJump(Mario mario) : base(mario)
        {
            mario.Sprite = SpriteFactory.CreateSprite("small_jump_left");
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
            mario.State = new MarioStateSmallLeftIdle(mario);
        }

        public override void Big()
        {
            mario.State = new MarioStateBigLeftJump(mario);
        }

        public override void Fire()
        {
            mario.State = new MarioStateFireLeftJump(mario);
        }

        public override void Star()
        {
            mario.State = new MarioStateStarSmallLeftJump(mario);
        }
    }
}
