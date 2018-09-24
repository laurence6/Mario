namespace MarioPirates
{

    public class MarioStateSmallRightCrouch : MarioStateSmall
    {
        public MarioStateSmallRightCrouch(Mario mario) : base(mario)
        {
        }

        public override void Jump()
        {
            mario.State = new MarioStateSmallRightIdle(mario);
        }

        public override void Crouch()
        {
        }

        public override void Small()
        {
        }

        public override void Big()
        {
            mario.State = new MarioStateBigRightCrouch(mario);
        }

        public override void Fire()
        {
            mario.State = new MarioStateFireRightCrouch(mario);
        }

        public override void Update()
        {
            mario.DrawSrc.X = 330;
            mario.DrawSrc.Y = 0;
            base.Update();
        }
    }

}
