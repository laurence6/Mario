using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal class Goomba : GameObjectRigidBody
    {
        private const int goombaWidth = 16, goombaHeight = 16;

        public Goomba(int x, int y)
        {
            location.X = x;
            location.Y = y;
            size = new Point(goombaWidth * 2, goombaHeight * 2);
            Sprite = SpriteFactory.Instance.CreateSprite("goomba");
        }

        public override void OnCollide(GameObject other, CollisionSide side)
        {
            if (other is Mario)
            {
                if (side == CollisionSide.Top)
                {
                    Sprite = SpriteFactory.Instance.CreateSprite("goomba_stomped");
                    RigidBody.Velocity = new Vector2(0f, 0f);
                }
            }
        }
    }
}
