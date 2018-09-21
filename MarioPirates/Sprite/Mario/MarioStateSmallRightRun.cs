namespace MarioPirates
{

    public class MarioStateSmallRightRun : MarioStateSmall
    {
        private const uint framesPerSprite = 15;
        private uint frameCount;

        public MarioStateSmallRightRun(Mario mario) : base(mario)
        {
            frameCount = 0;
        }

        public override void Left()
        {
            mario.State = new MarioStateSmallRightIdle(mario);
        }

        public override void Right()
        {
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
            mario.State = new MarioStateBigRightRun(mario);
        }

        public override void Fire()
        {
            mario.State = new MarioStateFireRightRun(mario);
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
                        mario.DrawSrc.X = 210;
                        mario.DrawSrc.Y = 0;
                        break;
                    case 1:
                    case 3:
                        mario.DrawSrc.X = 240;
                        mario.DrawSrc.Y = 0;
                        break;
                    case 2:
                        mario.DrawSrc.X = 270;
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
