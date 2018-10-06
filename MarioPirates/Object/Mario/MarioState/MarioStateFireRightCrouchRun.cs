using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal class MarioStateFireRightCrouchRun : MarioStateFire
    {
        public MarioStateFireRightCrouchRun(Mario mario) : base(mario)
        {
            mario.Size = new Point(marioWidth, marioHeight);
            mario.Sprite = SpriteFactory.CreateSprite("fire_crouch_right");
        }

        public override void Left()
        {
            mario.State = new MarioStateFireRightCrouch(mario);
        }

        public override void Right()
        {
        }

        public override void Jump()
        {
            mario.State = new MarioStateFireRightRun(mario);
        }

        public override void Crouch()
        {
        }

        public override void Small()
        {
            mario.State = new MarioStateSmallRightCrouchRun(mario);
        }

        public override void Big()
        {
            mario.State = new MarioStateBigRightCrouchRun(mario);
        }

        public override void Star()
        {
            mario.State = new MarioStateStarBigRightCrouchRun(mario);
        }
    }
}
