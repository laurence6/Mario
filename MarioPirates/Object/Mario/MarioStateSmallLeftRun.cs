namespace MarioPirates
{

    public class MarioStateSmallLeftRun : MarioStateSmall
    {

        public MarioStateSmallLeftRun(Mario mario) : base(mario)
        {
            mario.sprite = SpriteFactory.Instance.CreateSprite("mario_small_run_left");
        }

        public override void Left()
        {
        }

        public override void Right()
        {
            mario.State = new MarioStateSmallLeftIdle(mario);
        }

        public override void Jump()
        {
            mario.State = new MarioStateSmallLeftJump(mario);
        }

        public override void Crouch()
        {
            mario.State = new MarioStateSmallLeftCrouch(mario);
        }

        public override void Small()
        {
        }

        public override void Big()
        {
            mario.State = new MarioStateBigLeftRun(mario);
        }

        public override void Fire()
        {
            mario.State = new MarioStateFireLeftRun(mario);
        }
    }

}
