using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal class MarioStateBigLeftCrouchRun : MarioStateBig
    {
        public MarioStateBigLeftCrouchRun(Mario mario) : base(mario)
        {
            mario.Size = new Point(marioCrouchWidth, marioCrouchHeight);
            mario.Sprite = SpriteFactory.CreateSpriteMario("big_crouch_left");
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

        public override void Big()
        {
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
