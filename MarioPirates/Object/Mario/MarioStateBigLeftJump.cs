namespace MarioPirates
{

    public class MarioStateBigLeftJump : MarioStateBig
    {
        public MarioStateBigLeftJump(Mario mario) : base(mario)
        {
        }

        public override void Jump()
        {
        }

        public override void Crouch()
        {
            mario.State = new MarioStateBigLeftIdle(mario);
        }

        public override void Small()
        {
            mario.State = new MarioStateSmallLeftJump(mario);
        }

        public override void Big()
        {
        }

        public override void Fire()
        {
            mario.State = new MarioStateFireLeftJump(mario);
        }

        public override void Update()
        {
            mario.DrawSrc.X = 30;
            mario.DrawSrc.Y = 0;
            base.Update();
        }
    }

}
