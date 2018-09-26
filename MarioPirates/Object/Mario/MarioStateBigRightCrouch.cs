namespace MarioPirates
{

    public class MarioStateBigRightCrouch : MarioStateBig
    {
        public MarioStateBigRightCrouch(Mario mario) : base(mario)
        {
            mario.sprite = SpriteFactory.Instance.CreateSprite("mario_big_crouch_right");
        }

        public override void Jump()
        {
            mario.State = new MarioStateBigRightIdle(mario);
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
        }

        public override void Fire()
        {
            mario.State = new MarioStateFireRightCrouch(mario);
        }
    }

}
