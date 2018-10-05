namespace MarioPirates
{
    internal class MarioStateStarSmallLeftIdle : MarioStateStarSmall
    {
        public MarioStateStarSmallLeftIdle(Mario mario) : base(mario)
        {
            mario.Sprite = SpriteFactory.Instance.CreateSprite("star_small_idle_left");
        }

        public override void Left()
        {
            mario.State = new MarioStateStarSmallLeftRun(mario);
        }

        public override void Right()
        {
            mario.State = new MarioStateStarSmallRightRun(mario);
        }

        public override void Jump()
        {
            mario.State = new MarioStateStarSmallLeftJump(mario);
        }

        public override void Crouch()
        {
            mario.State = new MarioStateStarSmallLeftCrouch(mario);
        }

        public override void Big()
        {
            mario.State = new MarioStateStarBigLeftIdle(mario);
        }

        public override void Fire()
        {
            mario.State = new MarioStateStarBigLeftIdle(mario);
        }
    }
}
