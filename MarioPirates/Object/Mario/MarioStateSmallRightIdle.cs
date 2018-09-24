namespace MarioPirates
{

    public class MarioStateSmallRightIdle : MarioStateSmall
    {
        public MarioStateSmallRightIdle(Mario mario) : base(mario)
        {
        }

        public override void Left()
        {
            mario.State = new MarioStateSmallLeftIdle(mario);
        }

        public override void Right()
        {
            mario.State = new MarioStateSmallRightRun(mario);
        }

        public override void Jump()
        {
            mario.State = new MarioStateSmallRightJump(mario);
        }

        public override void Crouch()
        {
            mario.State = new MarioStateSmallRightCrouch(mario);
        }

        public override void Small()
        {
        }

        public override void Big()
        {
            mario.State = new MarioStateBigRightIdle(mario);
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
