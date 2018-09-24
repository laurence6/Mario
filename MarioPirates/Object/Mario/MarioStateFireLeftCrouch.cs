namespace MarioPirates
{

    public class MarioStateFireLeftCrouch : MarioStateFire
    {
        public MarioStateFireLeftCrouch(Mario mario) : base(mario)
        {
        }

        public override void Jump()
        {
            mario.State = new MarioStateFireLeftIdle(mario);
        }

        public override void Crouch()
        {
        }

        public override void Small()
        {
            mario.State = new MarioStateSmallLeftCrouch(mario);
        }

        public override void Big()
        {
            mario.State = new MarioStateBigLeftCrouch(mario);
        }

        public override void Fire()
        {
        }

        public override void Update()
        {
            mario.DrawSrc.X = 0;
            mario.DrawSrc.Y = 0;
            base.Update();
        }
    }

}
