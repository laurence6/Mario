using Microsoft.Xna.Framework;

namespace MarioPirates
{

    public class MarioStateFireRightCrouch : MarioStateFire
    {
        public MarioStateFireRightCrouch(Mario mario) : base(mario)
        {
            mario.size = new Point(marioCrouchWidth, marioCrouchHeight);
            mario.sprite = SpriteFactory.Instance.CreateSprite("mario_fire_crouch_right");
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
