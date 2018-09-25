namespace MarioPirates
{

    public class MarioStateSmallRightRun : MarioStateSmall
    {
        private const uint framesPerSprite = 15;
        private uint frameCount = 0;

        public MarioStateSmallRightRun(Mario mario, int dstX, int dstY) : base(mario, dstX, dstY)
        {
                mario.State = SpriteFactory.Instance.CreateSprite("mario_small_run_right");
        }

        public override void Left()
        {
            mario.State = new MarioStateSmallRightIdle(mario, location.X, location.Y);
        }

        public override void Right()
        {
        }

        public override void Jump()
        {
            mario.State = new MarioStateSmallRightJump(mario, location.X, location.Y);
        }

        public override void Crouch()
        {
            mario.State = new MarioStateSmallRightCrouch(mario, location.X, location.Y);
        }

        public override void Small()
        {
        }

        public override void Big()
        {
            mario.State = new MarioStateBigRightRun(mario, location.X, location.Y);
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
