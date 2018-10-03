namespace MarioPirates
{
    internal class MarioStateFireRightIdle : MarioStateFire
    {
        public MarioStateFireRightIdle(Mario mario) : base(mario)
        {
            mario.Sprite = SpriteFactory.Instance.CreateSprite("fire_idle_right");
        }

        public override void Left()
        {
            mario.State = new MarioStateFireLeftRun(mario);
        }

        public override void Right()
        {
            mario.State = new MarioStateFireRightRun(mario);
        }

        public override void Jump()
        {
            mario.State = new MarioStateFireRightJump(mario);
        }

        public override void Crouch()
        {
            mario.State = new MarioStateFireRightCrouch(mario);
        }

        public override void Small()
        {
            mario.State = new MarioStateSmallRightIdle(mario);
        }

        public override void Big()
        {
            mario.State = new MarioStateBigRightIdle(mario);
        }

        public override void Star()
        {
            mario.State = new MarioStateStarBigRightIdle(mario);
        }
    }
}
