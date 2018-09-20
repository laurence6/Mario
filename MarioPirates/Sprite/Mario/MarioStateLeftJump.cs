namespace MarioPirates
{

    public class MarioStateLeftJump : MarioState
    {
        public MarioStateLeftJump(Mario mario) : base(mario)
        {
        }

        public override void Jump()
        {
            mario.State = new MarioStateLeftJump(mario);
        }

        public override void Crouch()
        {
            mario.State = new MarioStateLeftIdle(mario);
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
