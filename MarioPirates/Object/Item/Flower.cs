using Microsoft.Xna.Framework;

namespace MarioPirates
{
    public class Flower : GameObject
    {
        private const int flowerWidth = 30, flowerHeight = 20;
        public Flower(int dstX, int dstY)
        {
            location.X = dstX;
            location.Y = dstY;
            size = new Point(flowerWidth * 2, flowerHeight * 2);
            sprite = SpriteFactory.Instance.CreateSprite("flower");
        }
    }
}
