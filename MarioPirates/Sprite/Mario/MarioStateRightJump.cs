namespace MarioPirates
{

    public class MarioStateRightJump : MarioState
    {
        public MarioStateRightJump(Mario mario) : base(mario)
        {
        }

        public override void Jump()
        {
            mario.State = new MarioStateRightJump(mario);
        }

        public override void Crouch()
        {
            mario.State = new MarioStateRightIdle(mario);
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
