namespace MarioPirates
{

    public class MarioStateBigLeftRun : MarioStateBig
    {
        private const uint framesPerSprite = 15;
        private uint frameCount = 0;

        public MarioStateBigLeftRun(Mario mario, int dstX, int dstY) : base(mario, dstX, dstY)
        {
            mario.State = SpriteFactory.Instance.CreateSprite("mario_big_run_left");
        }

        public override void Left()
        {
        }

        public override void Right()
        {
            mario.State = new MarioStateBigLeftIdle(mario);
        }

        public override void Jump()
        {
            mario.State = new MarioStateBigLeftJump(mario);
        }

        public override void Crouch()
        {
            mario.State = new MarioStateBigLeftCrouch(mario);
        }

        public override void Small()
        {
            mario.State = new MarioStateSmallLeftRun(mario);
        }

        public override void Big()
        {
        }

        public override void Fire()
        {
            mario.State = new MarioStateFireLeftRun(mario);
        }

        public override void Update()
        {
            if (frameCount % framesPerSprite == 0)
            {
                switch (frameCount / framesPerSprite % 4)
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
            base.Update();
            frameCount++;
        }
    }

}
