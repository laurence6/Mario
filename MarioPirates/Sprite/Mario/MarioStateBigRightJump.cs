namespace MarioPirates
{

    public class MarioStateBigRightJump : MarioStateBig
    {
        public MarioStateBigRightJump(Mario mario) : base(mario)
        {
        }

        public override void Jump()
        {
        }

        public override void Crouch()
        {
            mario.State = new MarioStateBigRightIdle(mario);
        }

        public override void Small()
        {
            mario.State = new MarioStateSmallRightJump(mario);
        }

        public override void Big()
        {
        }

        public override void Fire()
        {
            mario.State = new MarioStateFireRightJump(mario);
        }

        public override void Update()
        {
            mario.DrawSrc.X = 300;
            mario.DrawSrc.Y = 0;
            mario.DrawSrc.Width = marioWidth;
            mario.DrawSrc.Height = marioHeight;
            mario.DrawDst.Width = marioWidth * zoom;
            mario.DrawDst.Height = marioHeight * zoom;
        }
    }

}
