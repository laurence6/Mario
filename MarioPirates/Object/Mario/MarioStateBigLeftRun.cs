namespace MarioPirates
{

    public class MarioStateBigLeftRun : MarioStateBig
    {
        public MarioStateBigLeftRun(Mario mario) : base(mario)
        {
            mario.sprite = SpriteFactory.Instance.CreateSprite("mario_big_run_left");
        }

        public override void Left()
        {
        }

        public override void Right()
        {
            mario.State = new MarioStateBigLeftIdle(mario);
        }

        public override void Jump()
        {
            mario.State = new MarioStateBigLeftJump(mario);
        }

        public override void Crouch()
        {
            mario.State = new MarioStateBigLeftCrouch(mario);
        }

        public override void Small()
        {
            mario.State = new MarioStateSmallLeftRun(mario);
        }

        public override void Big()
        {
        }

        public override void Fire()
        {
            mario.State = new MarioStateFireLeftRun(mario);
        }
    }

}
