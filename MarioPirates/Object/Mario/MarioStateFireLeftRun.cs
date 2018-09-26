namespace MarioPirates
{

    public class MarioStateFireLeftRun : MarioStateFire
    {
        public MarioStateFireLeftRun(Mario mario) : base(mario)
        {
            mario.sprite = SpriteFactory.Instance.CreateSprite("mario_fire_run_left");
        }

        public override void Left()
        {
        }

        public override void Right()
        {
            mario.State = new MarioStateFireLeftIdle(mario);
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
            mario.State = new MarioStateSmallLeftRun(mario);
        }

        public override void Big()
        {
            mario.State = new MarioStateBigLeftRun(mario);
        }

        public override void Fire()
        {
        }
    }

}
