namespace MarioPirates
{

    public class MarioStateBigRightRun : MarioStateBig
    {
        public MarioStateBigRightRun(Mario mario) : base(mario)
        {
            mario.sprite = SpriteFactory.Instance.CreateSprite("mario_big_run_right");
        }

        public override void Left()
        {
            mario.State = new MarioStateBigRightIdle(mario);
        }

        public override void Right()
        {
        }

        public override void Jump()
        {
            mario.State = new MarioStateBigRightJump(mario);
        }

        public override void Crouch()
        {
            mario.State = new MarioStateBigRightCrouch(mario);
        }

        public override void Small()
        {
            mario.State = new MarioStateSmallRightRun(mario);
        }

        public override void Big()
        {
        }

        public override void Fire()
        {
            mario.State = new MarioStateFireRightRun(mario);
        }
    }

}
