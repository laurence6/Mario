namespace MarioPirates
{

    public class MarioStateRightIdle : MarioState
    {
        public MarioStateRightIdle(Mario mario) : base(mario)
        {
        }

        public override void Left()
        {
            mario.State = new MarioStateLeftIdle(mario);
        }

        public override void Right()
        {
            mario.State = new MarioStateRightRun(mario);
        }

        public override void Jump()
        {
            mario.State = new MarioStateRightJump(mario);
        }

        public override void Crouch()
        {
            mario.State = new MarioStateRightCrouch(mario);
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
