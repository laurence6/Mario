using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal class Koopa : GameObjectRigidBody
    {
        private const int koopaWidth = 16, koopaHeight = 23;

        private bool stopmed;
        private Sprite[] sprites;

        public Koopa(int x, int y)
        {
            location.X = x;
            location.Y = y;
            size = new Point(koopaWidth * 2, koopaHeight * 2);
            RigidBody.Mass = 0.1f;

            stopmed = false;
            sprites = new Sprite[3] {
                SpriteFactory.Instance.CreateSprite("koopa_left"),
                SpriteFactory.Instance.CreateSprite("koopa_right"),
                SpriteFactory.Instance.CreateSprite("koopa_stomped"),
            };
            Sprite = sprites[0];
        }

        public override void Update(float dt)
        {
            Sprite = stopmed ? sprites[2] : RigidBody.Velocity.X < 0 ? sprites[0] : sprites[1];
            base.Update(dt);
        }

        public override void OnCollide(GameObject other, CollisionSide side)
        {
            if (other is Mario)
                if (side == CollisionSide.Top)
                    stopmed = true;
        }
    }
}
