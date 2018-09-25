namespace MarioPirates
{

    public class MarioStateFireLeftIdle : MarioStateFire
    {
        public MarioStateFireLeftIdle(Mario mario) : base(mario)
        {
        }

        public override void Left()
        {
            mario.State = new MarioStateFireLeftRun(mario);
        }

        public override void Right()
        {
            mario.State = new MarioStateFireRightIdle(mario);
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
            mario.State = new MarioStateSmallLeftIdle(mario);
        }

        public override void Big()
        {
            mario.State = new MarioStateBigLeftIdle(mario);
        }

        public override void Fire()
        {
        }

        public override void Update()
        {
            mario.DrawSrc.X = 150;
            mario.DrawSrc.Y = 0;
            base.Update();
        }
    }

}