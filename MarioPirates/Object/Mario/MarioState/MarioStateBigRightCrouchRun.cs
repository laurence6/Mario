using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal class MarioStateBigRightCrouchRun : MarioStateBig
    {
        public MarioStateBigRightCrouchRun(Mario mario) : base(mario)
        {
            mario.Size = new Point(marioWidth, marioHeight);
            mario.Sprite = SpriteFactory.CreateSprite("big_crouch_right");
        }

        public override void Left()
        {
            mario.State = new MarioStateBigRightCrouch(mario);
        }

        public override void Right()
        {
        }

        public override void Jump()
        {
            mario.State = new MarioStateBigRightRun(mario);
        }

        public override void Crouch()
        {
        }

        public override void Small()
        {
            mario.State = new MarioStateSmallRightCrouchRun(mario);
        }

        public override void Fire()
        {
            mario.State = new MarioStateFireRightCrouchRun(mario);
        }

        public override void Star()
        {
            mario.State = new MarioStateStarBigRightCrouchRun(mario);
        }
    }
}
