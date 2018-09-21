namespace MarioPirates
{

    public class MarioStateFireRightIdle : MarioStateFire
    {
        public MarioStateFireRightIdle(Mario mario) : base(mario)
        {
        }

        public override void Left()
        {
            mario.State = new MarioStateFireLeftIdle(mario);
        }

        public override void Right()
        {
            mario.State = new MarioStateFireRightRun(mario);
        }

        public override void Jump()
        {
            mario.State = new MarioStateFireRightJump(mario);
        }

        public override void Crouch()
        {
            mario.State = new MarioStateFireRightCrouch(mario);
        }

        public override void Small()
        {
            mario.State = new MarioStateSmallRightIdle(mario);
        }

        public override void Big()
        {
            mario.State = new MarioStateBigRightIdle(mario);
        }

        public override void Fire()
        {
        }

        public override void Update()
        {
            mario.DrawSrc.X = 180;
            mario.DrawSrc.Y = 0;
            mario.DrawSrc.Width = marioWidth;
            mario.DrawSrc.Height = marioHeight;
            mario.DrawDst.Width = marioWidth * zoom;
            mario.DrawDst.Height = marioHeight * zoom;
        }
    }

}
