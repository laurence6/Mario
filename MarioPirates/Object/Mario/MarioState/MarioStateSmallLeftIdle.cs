namespace MarioPirates
{
    internal class MarioStateSmallLeftIdle : MarioStateSmall
    {
        public MarioStateSmallLeftIdle(Mario mario) : base(mario)
        {
            mario.Sprite = SpriteFactory.Instance.CreateSprite("small_idle_left");
        }

        public override void Left()
        {
            mario.State = new MarioStateSmallLeftRun(mario);
        }

        public override void Right()
        {
            mario.State = new MarioStateSmallRightRun(mario);
        }

        public override void Jump()
        {
            mario.State = new MarioStateSmallLeftJump(mario);
        }

        public override void Crouch()
        {
            mario.State = new MarioStateSmallLeftCrouch(mario);
        }

        public override void Big()
        {
            mario.State = new MarioStateBigLeftIdle(mario);
        }

        public override void Fire()
        {
            mario.State = new MarioStateFireLeftIdle(mario);
        }

        public override void Star()
        {
            mario.State = new MarioStateStarSmallLeftIdle(mario);
        }
    }
}
