namespace MarioPirates
{

    public class MarioStateFireRightIdle : MarioStateFire
    {
        public MarioStateFireRightIdle(Mario mario, int dstX, int dstY) : base(mario, dstX, dstY)
        {
            mario.State = SpriteFactory.Instance.CreateSprite("mario_fire_idle_right");
        }

        public override void Left()
        {
            mario.State = new MarioStateFireLeftIdle(mario, location.X, location.Y);
        }

        public override void Right()
        {
            mario.State = new MarioStateFireRightRun(mario, location.X, location.Y);
        }

        public override void Jump()
        {
            mario.State = new MarioStateFireRightJump(mario, location.X, location.Y);
        }

        public override void Crouch()
        {
            mario.State = new MarioStateFireRightCrouch(mario, location.X, location.Y);
        }

        public override void Small()
        {
            mario.State = new MarioStateSmallRightIdle(mario, location.X, location.Y);
        }

        public override void Big()
        {
            mario.State = new MarioStateBigRightIdle(mario, location.X, location.Y);
        }

        public override void Fire()
        {
        }
    }

}
