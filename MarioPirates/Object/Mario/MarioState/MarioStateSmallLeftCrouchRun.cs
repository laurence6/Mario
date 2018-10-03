namespace MarioPirates
{
    internal class MarioStateSmallLeftCrouchRun : MarioStateSmall
    {
        public MarioStateSmallLeftCrouchRun(Mario mario) : base(mario)
        {
            mario.Sprite = SpriteFactory.Instance.CreateSprite("small_crouch_left");
        }

        public override void Left()
        {
        }

        public override void Right()
        {
            mario.State = new MarioStateSmallLeftCrouch(mario);
        }

        public override void Jump()
        {
            mario.State = new MarioStateSmallLeftRun(mario);
        }

        public override void Crouch()
        {
        }

        public override void Big()
        {
            mario.State = new MarioStateBigLeftCrouchRun(mario);
        }

        public override void Fire()
        {
            mario.State = new MarioStateFireLeftCrouchRun(mario);
        }

        public override void Star()
        {
            mario.State = new MarioStateStarSmallLeftCrouchRun(mario);
        }
    }
}
