namespace MarioPirates
{
    internal class MarioStateFireLeftJumpRun : MarioStateFire
    {
        public MarioStateFireLeftJumpRun(Mario mario) : base(mario)
        {
            mario.Sprite = SpriteFactory.CreateSpriteMario("fire_jump_left");
        }

        public override void Left()
        {
        }

        public override void Right()
        {
            mario.State = new MarioStateFireLeftJump(mario);
        }

        public override void Jump()
        {
        }

        public override void Crouch()
        {
            mario.State = new MarioStateFireLeftRun(mario);
        }

        public override void Small()
        {
            mario.State = new MarioStateSmallLeftJumpRun(mario);
        }

        public override void Big()
        {
            mario.State = new MarioStateBigLeftJumpRun(mario);
        }

        public override void Star()
        {
            mario.State = new MarioStateStarBigLeftJumpRun(mario);
        }
    }
}
