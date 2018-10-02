using Microsoft.Xna.Framework;

namespace MarioPirates
{
    using Event;
    internal class Coin : GameObject
    {
        private const int coinWidth = 7, coinHeight = 14;
        public Coin(int dstX, int dstY)
        {
            location.X = dstX;
            location.Y = dstY;
            size = new Point(coinWidth * 2, coinHeight * 2);
            Sprite = SpriteFactory.CreateSprite("coins");
        }
        public override void OnCollide(GameObject obj)
        {
            if(obj is Mario)
            {
                EventManager.Instance.EnqueueEvent(new GameObjectDestroyEvent(this));
            }
        }
    }
}
