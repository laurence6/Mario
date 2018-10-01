using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal class MarioStateFireRightCrouch : MarioStateFire
    {
        public MarioStateFireRightCrouch(Mario mario) : base(mario)
        {
            mario.Size = new Point(marioCrouchWidth, marioCrouchHeight);
            mario.Sprite = SpriteFactory.CreateSpriteMario("fire_crouch_right");
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
            mario.State = new MarioStateFireRightIdle(mario);
        }

        public override void Crouch()
        {
        }

        public override void Small()
        {
            mario.State = new MarioStateSmallRightCrouch(mario);
        }

        public override void Big()
        {
            mario.State = new MarioStateBigRightCrouch(mario);
        }

        public override void Fire()
        {
        }
    }
}