using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal class MarioStateBigLeftCrouch : MarioStateBig
    {
        public MarioStateBigLeftCrouch(Mario mario) : base(mario)
        {
            mario.Size = new Point(marioCrouchWidth, marioCrouchHeight);
            mario.Sprite = SpriteFactory.CreateSpriteMario("big_crouch_left");
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

        public override void Big()
        {
        }

        public override void Fire()
        {
            mario.State = new MarioStateFireLeftCrouch(mario);
        }
    }
}