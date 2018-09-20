namespace MarioPirates
{

    public class MarioStateLeftRun : MarioState
    {
        private const uint framesPerSprite = 15;
        private uint frameCount;

        public MarioStateLeftRun(Mario mario) : base(mario)
        {
            frameCount = 0;
        }

        public override void Left()
        {
        }

        public override void Right()
        {
            mario.State = new MarioStateLeftIdle(mario);
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
            if (frameCount++ / framesPerSprite >= 4)
            {
                frameCount = 0;
            }
            if (frameCount % framesPerSprite == 0)
            {
                switch (frameCount / framesPerSprite)
                {
                    case 0:
                        mario.DrawSrc.X = 120;
                        mario.DrawSrc.Y = 0;
                        break;
                    case 1:
                    case 3:
                        mario.DrawSrc.X = 90;
                        mario.DrawSrc.Y = 0;
                        break;
                    case 2:
                        mario.DrawSrc.X = 60;
                        mario.DrawSrc.Y = 0;
                        break;
                    default:
                        break;
                }
            }
            mario.DrawSrc.Width = marioWidth;
            mario.DrawSrc.Height = marioHeight;
            mario.DrawDst.Width = marioWidth * zoom;
            mario.DrawDst.Height = marioHeight * zoom;
        }
    }

}
