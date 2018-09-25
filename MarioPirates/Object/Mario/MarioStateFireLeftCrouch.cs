using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal class MarioStateFireLeftCrouch : MarioStateFire
    {
        public MarioStateFireLeftCrouch(Mario mario) : base(mario)
        {
            mario.size = new Point(marioCrouchWidth, marioCrouchHeight);
            mario.sprite = SpriteFactory.Instance.CreateSprite("mario_fire_crouch_left");
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

        public override void Fire()
        {
        }
    }

}
