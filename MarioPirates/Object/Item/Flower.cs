using Microsoft.Xna.Framework;

namespace MarioPirates
{
    public class Flower : GameObject
    {
        public Flower(int dstX, int dstY)
        {
            location.X = dstX;
            location.Y = dstY;
            size = new Point(size.X * 2, size.Y * 2);
            sprite = SpriteFactory.Instance.CreateSprite("flower");
        }
    }
}
