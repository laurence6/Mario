using Microsoft.Xna.Framework;

namespace MarioPirates
{
    using Event;
    internal class GreenMushroom : GameObjectRigidBody
    {
        private const int greenMushroomWidth = 16, greenMushroomHeight = 16;
        public GreenMushroom(int dstX, int dstY)
        {
            location.X = dstX;
            location.Y = dstY;
            size = new Point(greenMushroomWidth * 2, greenMushroomHeight * 2);
            Sprite = SpriteFactory.Instance.CreateSprite("greenmushroom");
        }
        public override void OnCollide(GameObject other, CollisionSide side)
        {
            if (other is Mario)
            {
                EventManager.Instance.EnqueueEvent(new GameObjectDestroyEvent(this));
            }
        }
    }
}
