namespace MarioPirates
{

    public class MarioStateLeftIdle : MarioState
    {
        public MarioStateLeftIdle(Mario mario) : base(mario)
        {
        }

        public override void Left()
        {
            mario.State = new MarioStateLeftRun(mario);
        }

        public override void Right()
        {
            mario.State = new MarioStateRightIdle(mario);
        }

        public override void Jump()
        {
            mario.State = new MarioStateLeftJump(mario);
        }

        public override void Crouch()
        {
            mario.State = new MarioStateLeftCrouch(mario);
        }

        public override void Update()
        {
            mario.DrawSrc.X = 150;
            mario.DrawSrc.Y = 0;
            mario.DrawSrc.Width = marioWidth;
            mario.DrawSrc.Height = marioHeight;
            mario.DrawDst.Width = marioWidth * zoom;
            mario.DrawDst.Height = marioHeight * zoom;
        }
    }

}
