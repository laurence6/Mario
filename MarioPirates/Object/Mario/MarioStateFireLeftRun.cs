namespace MarioPirates
{

    public class MarioStateFireLeftRun : MarioStateFire
    {
        private const uint framesPerSprite = 15;
        private uint frameCount = 0;

        public MarioStateFireLeftRun(Mario mario, int dstX, int dstY) : base(mario, dstX, dstY)
        {
            mario.State = SpriteFactory.Instance.CreateSprite("mario_fire_run_left");
        }

        public override void Left()
        {
        }

        public override void Right()
        {
            mario.State = new MarioStateFireLeftIdle(mario, location.X, location.Y);
        }

        public override void Jump()
        {
            mario.State = new MarioStateFireLeftJump(mario, location.X, location.Y);
        }

        public override void Crouch()
        {
            mario.State = new MarioStateFireLeftCrouch(mario, location.X, location.Y);
        }

        public override void Small()
        {
            mario.State = new MarioStateSmallLeftRun(mario, location.X, location.Y);
        }

        public override void Big()
        {
            mario.State = new MarioStateBigLeftRun(mario, location.X, location.Y);
        }

        public override void Fire()
        {
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
