using Microsoft.Xna.Framework;

namespace MarioPirates
{
    using Event;

    internal class Flower : GameObjectRigidBody
    {
        private const int flowerWidth = 16, flowerHeight = 16;

        public Flower(int dstX, int dstY)
        {
            location.X = dstX;
            location.Y = dstY;
            size = new Point(flowerWidth * 2, flowerHeight * 2);
            Sprite = SpriteFactory.Instance.CreateSprite("flower");
            RigidBody.Mass = 0.05f;
        }

        public override void OnCollide(GameObject other, CollisionSide side)
        {
            if (other is Mario)
            {
                EventManager.Instance.TriggerEvent(new GameObjectDestroyEvent(this));
            }
        }
    }
}
