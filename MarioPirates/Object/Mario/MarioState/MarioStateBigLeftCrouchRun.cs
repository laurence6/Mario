using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal class MarioStateBigLeftCrouchRun : MarioStateBig
    {
        public MarioStateBigLeftCrouchRun(Mario mario) : base(mario)
        {
            mario.Size = new Point(marioWidth, marioHeight);
            mario.Sprite = SpriteFactory.Instance.CreateSprite("big_crouch_left");
        }

        public override void Left()
        {
        }

        public override void Right()
        {
            mario.State = new MarioStateBigLeftCrouch(mario);
        }

        public override void Jump()
        {
            mario.State = new MarioStateBigLeftRun(mario);
        }

        public override void Crouch()
        {
        }

        public override void Small()
        {
            mario.State = new MarioStateSmallLeftCrouchRun(mario);
        }

        public override void Fire()
        {
            mario.State = new MarioStateFireLeftCrouchRun(mario);
        }

        public override void Star()
        {
            mario.State = new MarioStateStarBigLeftCrouchRun(mario);
        }
    }
}
