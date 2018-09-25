namespace MarioPirates
{

    public class MarioStateFireRightCrouch : MarioStateFire
    {
        public MarioStateFireRightCrouch(Mario mario) : base(mario)
        {
        }

        public override void Jump()
        {
            mario.State = new MarioStateFireRightIdle(mario);
        }

        public override void Crouch()
        {
        }

        public override void Small()
        {
            mario.State = new MarioStateSmallRightCrouch(mario);
        }

        public override void Big()
        {
            mario.State = new MarioStateBigRightCrouch(mario);
        }

        public override void Fire()
        {
        }

        public override void Update()
        {
            mario.DrawSrc.X = 330;
            mario.DrawSrc.Y = 0;
            base.Update();
        }
    }

}