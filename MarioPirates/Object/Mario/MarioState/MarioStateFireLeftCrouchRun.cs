using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal class MarioStateFireLeftCrouchRun : MarioStateFire
    {
        public MarioStateFireLeftCrouchRun(Mario mario) : base(mario)
        {
            mario.Size = new Point(marioCrouchWidth, marioCrouchHeight);
            mario.Sprite = SpriteFactory.CreateSpriteMario("fire_crouch_left");
        }

        public override void Left()
        {
        }

        public override void Right()
        {
            mario.State = new MarioStateFireLeftCrouch(mario);
        }

        public override void Jump()
        {
            mario.State = new MarioStateFireLeftRun(mario);
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
            mario.State = new MarioStateBigLeftCrouchRun(mario);
        }

        public override void Star()
        {
            mario.State = new MarioStateStarBigLeftCrouchRun(mario);
        }
    }
}
