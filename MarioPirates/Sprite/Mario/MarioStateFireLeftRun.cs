namespace MarioPirates
{

    public class MarioStateFireLeftRun : MarioStateFire
    {
        private const uint framesPerSprite = 15;
        private uint frameCount = 0;

        public MarioStateFireLeftRun(Mario mario) : base(mario)
        {
        }

        public override void Left()
        {
        }

        public override void Right()
        {
            mario.State = new MarioStateFireLeftIdle(mario);
        }

        public override void Jump()
        {
            mario.State = new MarioStateFireLeftJump(mario);
        }

        public override void Crouch()
        {
            mario.State = new MarioStateFireLeftCrouch(mario);
        }

        public override void Small()
        {
            mario.State = new MarioStateSmallLeftRun(mario);
        }

        public override void Big()
        {
            mario.State = new MarioStateBigLeftRun(mario);
        }

        public override void Fire()
        {
        }

        public override void Update()
        {
            if (frameCount % framesPerSprite == 0)
            {
                switch (frameCount / framesPerSprite)
                {
                    case 0:
                        mario.DrawSrc.X = 129;
                        mario.DrawSrc.Y = 0;
                        break;
                    case 1:
                    case 3:
                        mario.DrawSrc.X = 103;
                        mario.DrawSrc.Y = 0;
                        break;
                    case 2:
                        mario.DrawSrc.X = 77;
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
