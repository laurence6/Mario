namespace MarioPirates
{
    internal class MarioStateBigLeftJumpRun : MarioStateBig
    {
        public MarioStateBigLeftJumpRun(Mario mario) : base(mario)
        {
            mario.Sprite = SpriteFactory.Instance.CreateSprite("big_jump_left");
        }

        public override void Left()
        {
        }

        public override void Right()
        {
            mario.State = new MarioStateBigLeftJump(mario);
        }

        public override void Jump()
        {
        }

        public override void Crouch()
        {
            mario.State = new MarioStateBigLeftRun(mario);
        }

        public override void Small()
        {
            mario.State = new MarioStateSmallLeftJumpRun(mario);
        }

        public override void Fire()
        {
            mario.State = new MarioStateFireLeftJumpRun(mario);
        }

        public override void Star()
        {
            mario.State = new MarioStateStarBigLeftJumpRun(mario);
        }
    }
}
