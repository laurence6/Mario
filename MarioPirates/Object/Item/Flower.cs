using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal class Flower : GameObject
    {
        private const int flowerWidth = 30, flowerHeight = 16;
        public Flower(int dstX, int dstY)
        {
            Location.X = dstX;
            Location.Y = dstY;
            Size = new Point(flowerWidth * 2, flowerHeight * 2);
            Sprite = SpriteFactory.Instance.CreateSprite("flower");
        }
    }
}
