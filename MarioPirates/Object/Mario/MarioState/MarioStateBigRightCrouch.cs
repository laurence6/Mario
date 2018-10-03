using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal class MarioStateBigRightCrouch : MarioStateBig
    {
        public MarioStateBigRightCrouch(Mario mario) : base(mario)
        {
            mario.Size = new Point(marioCrouchWidth, marioCrouchHeight);
            mario.Sprite = SpriteFactory.Instance.CreateSpriteMario("big_crouch_right");
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
            mario.State = new MarioStateBigRightIdle(mario);
        }

        public override void Crouch()
        {
        }

        public override void Small()
        {
            mario.State = new MarioStateSmallRightCrouch(mario);
        }

        public override void Fire()
        {
            mario.State = new MarioStateFireRightCrouch(mario);
        }

        public override void Star()
        {
            mario.State = new MarioStateStarBigRightCrouch(mario);
        }
    }
}
