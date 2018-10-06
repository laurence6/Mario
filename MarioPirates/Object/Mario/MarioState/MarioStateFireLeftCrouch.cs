using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal class MarioStateFireLeftCrouch : MarioStateFire
    {
        public MarioStateFireLeftCrouch(Mario mario) : base(mario)
        {
            mario.Size = new Point(marioWidth, marioHeight);
            mario.Sprite = SpriteFactory.CreateSprite("fire_crouch_left");
        }

        public override void Left()
        {
            mario.State = new MarioStateFireLeftCrouchRun(mario);
        }

        public override void Right()
        {
            mario.State = new MarioStateFireRightCrouchRun(mario);
        }

        public override void Jump()
        {
            mario.State = new MarioStateFireLeftIdle(mario);
        }

        public override void Crouch()
        {
        }

        public override void Small()
        {
            mario.State = new MarioStateSmallLeftCrouch(mario);
        }

        public override void Big()
        {
            mario.State = new MarioStateBigLeftCrouch(mario);
        }

        public override void Star()
        {
            mario.State = new MarioStateStarBigLeftCrouch(mario);
        }
    }
}
