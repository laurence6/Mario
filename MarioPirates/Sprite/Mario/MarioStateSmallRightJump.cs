namespace MarioPirates
{

    public class MarioStateSmallRightJump : MarioStateSmall
    {
        public MarioStateSmallRightJump(Mario mario) : base(mario)
        {
        }

        public override void Jump()
        {
        }

        public override void Crouch()
        {
            mario.State = new MarioStateSmallRightIdle(mario);
        }

        public override void Small()
        {
        }

        public override void Big()
        {
            mario.State = new MarioStateBigRightJump(mario);
        }

        public override void Fire()
        {
            mario.State = new MarioStateFireRightJump(mario);
        }

        public override void Update()
        {
            mario.DrawSrc.X = 300;
            mario.DrawSrc.Y = 0;
            base.Update();
        }
    }

}
