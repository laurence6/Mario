namespace MarioPirates
{

    public class MarioStateRightCrouch : MarioState
    {
        public MarioStateRightCrouch(Mario mario) : base(mario)
        {
        }

        public override void Jump()
        {
            mario.State = new MarioStateRightIdle(mario);
        }

        public override void Crouch()
        {
            mario.State = new MarioStateRightCrouch(mario);
        }

        public override void Update()
        {
            mario.DrawSrc.X = 330;
            mario.DrawSrc.Y = 0;
            mario.DrawSrc.Width = marioWidth;
            mario.DrawSrc.Height = marioHeight;
            mario.DrawDst.Width = marioWidth * zoom;
            mario.DrawDst.Height = marioHeight * zoom;
        }
    }

}
