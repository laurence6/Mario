namespace MarioPirates
{

    public class MarioStateLeftCrouch : MarioState
    {
        public MarioStateLeftCrouch(Mario mario) : base(mario)
        {
        }

        public override void Jump()
        {
            mario.State = new MarioStateLeftIdle(mario);
        }

        public override void Crouch()
        {
            mario.State = new MarioStateLeftCrouch(mario);
        }

        public override void Update()
        {
            mario.DrawSrc.X = 0;
            mario.DrawSrc.Y = 0;
            mario.DrawSrc.Width = marioWidth;
            mario.DrawSrc.Height = marioHeight;
            mario.DrawDst.Width = marioWidth * zoom;
            mario.DrawDst.Height = marioHeight * zoom;
        }
    }

}
