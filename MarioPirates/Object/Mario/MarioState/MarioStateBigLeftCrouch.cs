using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal class MarioStateBigLeftCrouch : MarioStateBig
    {
        public MarioStateBigLeftCrouch(Mario mario) : base(mario)
        {
            mario.Size = new Point(marioWidth, marioHeight);
            mario.Sprite = SpriteFactory.CreateSprite("big_crouch_left");
        }

        public override void Left()
        {
            mario.State = new MarioStateBigLeftCrouchRun(mario);
        }

        public override void Right()
        {
            mario.State = new MarioStateBigRightCrouchRun(mario);
        }

        public override void Jump()
        {
            mario.State = new MarioStateBigLeftIdle(mario);
        }

        public override void Crouch()
        {
        }

        public override void Small()
        {
            mario.State = new MarioStateSmallLeftCrouch(mario);
        }

        public override void Fire()
        {
            mario.State = new MarioStateFireLeftCrouch(mario);
        }

        public override void Star()
        {
            mario.State = new MarioStateStarBigLeftCrouch(mario);
        }
    }
}
