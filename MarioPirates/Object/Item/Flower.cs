using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal class Flower : GameObjectRigidBody
    {
        private const int flowerWidth = 16, flowerHeight = 16;
        public Flower(int dstX, int dstY)
        {
            location.X = dstX;
            location.Y = dstY;
            size = new Point(flowerWidth * 2, flowerHeight * 2);
            Sprite = SpriteFactory.Instance.CreateSprite("flower");
        }
        public override void OnCollide(GameObject other, CollisionSide side)
        {
            if (other is Mario)
            {

            }
        }
    }
}
