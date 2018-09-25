namespace MarioPirates
{

    public class MarioStateBigRightRun : MarioStateBig
    {
        private const uint framesPerSprite = 15;
        private uint frameCount = 0;

        public MarioStateBigRightRun(Mario mario, int dstX, int dstY) : base(mario, dstX, dstY)
        {
            mario.State = SpriteFactory.Instance.CreateSprite("mario_big_run_right");
        }

        public override void Left()
        {
            mario.State = new MarioStateBigRightIdle(mario, location.X, location.Y);
        }

        public override void Right()
        {
        }

        public override void Jump()
        {
            mario.State = new MarioStateBigRightJump(mario, location.X, location.Y);
        }

        public override void Crouch()
        {
            mario.State = new MarioStateBigRightCrouch(mario, location.X, location.Y);
        }

        public override void Small()
        {
            mario.State = new MarioStateSmallRightRun(mario, location.X, location.Y);
        }

        public override void Big()
        {
        }

        public override void Fire()
        {
            mario.State = new MarioStateFireRightRun(mario, location.X, location.Y);
        }

        public override void Update()
        {
            if (frameCount % framesPerSprite == 0)
            {
                switch (frameCount / framesPerSprite % 4)
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
            base.Update();
            frameCount++;
        }
    }

}
