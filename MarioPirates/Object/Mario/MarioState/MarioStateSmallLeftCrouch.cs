namespace MarioPirates
{
    internal class MarioStateSmallLeftCrouch : MarioStateSmall
    {
        public MarioStateSmallLeftCrouch(Mario mario) : base(mario)
        {
            mario.Sprite = SpriteFactory.Instance.CreateSprite("small_crouch_left");
        }

        public override void Left()
        {
            mario.State = new MarioStateSmallLeftCrouchRun(mario);
        }

        public override void Right()
        {
            mario.State = new MarioStateSmallRightCrouchRun(mario);
        }

        public override void Jump()
        {
            mario.State = new MarioStateSmallLeftIdle(mario);
        }

        public override void Crouch()
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

        public override void Star()
        {
            mario.State = new MarioStateStarSmallLeftCrouch(mario);
        }
    }
}
