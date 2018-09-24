namespace MarioPirates
{

    public class MarioStateSmallLeftCrouch : MarioStateSmall
    {
        public MarioStateSmallLeftCrouch(Mario mario) : base(mario)
        {
        }

        public override void Jump()
        {
            mario.State = new MarioStateSmallLeftIdle(mario);
        }

        public override void Crouch()
        {
        }

        public override void Small()
        {
        }

        public override void Big()
        {
            mario.State = new MarioStateBigLeftCrouch(mario);
        }

        public override void Fire()
        {
            mario.State = new MarioStateFireLeftCrouch(mario);
        }

        public override void Update()
        {
            mario.DrawSrc.X = 0;
            mario.DrawSrc.Y = 0;
            base.Update();
        }
    }

}
