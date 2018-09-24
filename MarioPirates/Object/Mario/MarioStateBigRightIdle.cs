namespace MarioPirates
{

    public class MarioStateBigRightIdle : MarioStateBig
    {
        public MarioStateBigRightIdle(Mario mario) : base(mario)
        {
        }

        public override void Left()
        {
            mario.State = new MarioStateBigLeftIdle(mario);
        }

        public override void Right()
        {
            mario.State = new MarioStateBigRightRun(mario);
        }

        public override void Jump()
        {
            mario.State = new MarioStateBigRightJump(mario);
        }

        public override void Crouch()
        {
            mario.State = new MarioStateBigRightCrouch(mario);
        }

        public override void Small()
        {
            mario.State = new MarioStateSmallRightIdle(mario);
        }

        public override void Big()
        {
        }

        public override void Fire()
        {
            mario.State = new MarioStateFireRightIdle(mario);
        }

        public override void Update()
        {
            mario.DrawSrc.X = 180;
            mario.DrawSrc.Y = 0;
            base.Update();
        }
    }

}
