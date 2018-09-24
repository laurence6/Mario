namespace MarioPirates
{

    public class MarioStateFireRightJump : MarioStateFire
    {
        public MarioStateFireRightJump(Mario mario) : base(mario)
        {
        }

        public override void Jump()
        {
        }

        public override void Crouch()
        {
            mario.State = new MarioStateFireRightIdle(mario);
        }

        public override void Small()
        {
            mario.State = new MarioStateSmallRightJump(mario);
        }

        public override void Big()
        {
            mario.State = new MarioStateBigRightJump(mario);
        }

        public override void Fire()
        {
        }

        public override void Update()
        {
            mario.DrawSrc.X = 300;
            mario.DrawSrc.Y = 0;
            base.Update();
        }
    }

}
