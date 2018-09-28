using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal class Coin : GameObject
    {
        private const int coinWidth = 30, coinHeight = 14;
        public Coin(int dstX, int dstY)
        {
            Location.X = dstX;
            Location.Y = dstY;
            Size = new Point(coinWidth * 2, coinHeight * 2);
            Sprite = SpriteFactory.CreateSprite("coins");
        }
    }
}
