namespace MarioPirates
{

    public class MarioStateFireLeftJump : MarioStateFire
    {
        public MarioStateFireLeftJump(Mario mario) : base(mario)
        {
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

        public override void Fire()
        {
        }

        public override void Update()
        {
            mario.DrawSrc.X = 26;
            mario.DrawSrc.Y = 0;
            mario.DrawSrc.Width = marioWidth;
            mario.DrawSrc.Height = marioHeight;
            mario.DrawDst.Width = marioWidth * zoom;
            mario.DrawDst.Height = marioHeight * zoom;
        }
    }

}
