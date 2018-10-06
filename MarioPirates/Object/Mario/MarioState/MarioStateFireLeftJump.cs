namespace MarioPirates
{
    internal class MarioStateFireLeftJump : MarioStateFire
    {
        public MarioStateFireLeftJump(Mario mario) : base(mario)
        {
            mario.Sprite = SpriteFactory.CreateSprite("fire_jump_left");
        }

        public override void Left()
        {
            mario.State = new MarioStateFireLeftJumpRun(mario);
        }

        public override void Right()
        {
            mario.State = new MarioStateFireRightJumpRun(mario);
        }

        public override void Jump()
        {
        }

        public override void Crouch()
        {
            mario.State = new MarioStateFireLeftIdle(mario);
        }

        public override void Small()
        {
            mario.State = new MarioStateSmallLeftJump(mario);
        }

        public override void Big()
        {
            mario.State = new MarioStateBigLeftJump(mario);
        }

        public override void Star()
        {
            mario.State = new MarioStateStarBigLeftJump(mario);
        }
    }
}
