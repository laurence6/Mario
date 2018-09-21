namespace MarioPirates
{

    public class MarioStateSmallLeftJump : MarioStateSmall
    {
        public MarioStateSmallLeftJump(Mario mario) : base(mario)
        {
        }

        public override void Jump()
        {
        }

        public override void Crouch()
        {
            mario.State = new MarioStateSmallLeftIdle(mario);
        }

        public override void Small()
        {
        }

        public override void Big()
        {
            mario.State = new MarioStateBigLeftJump(mario);
        }

        public override void Fire()
        {
            mario.State = new MarioStateFireLeftJump(mario);
        }

        public override void Update()
        {
            mario.DrawSrc.X = 30;
            mario.DrawSrc.Y = 0;
            mario.DrawSrc.Width = marioWidth;
            mario.DrawSrc.Height = marioHeight;
            mario.DrawDst.Width = marioWidth * zoom;
            mario.DrawDst.Height = marioHeight * zoom;
        }
    }

}
