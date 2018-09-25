using Microsoft.Xna.Framework;

namespace MarioPirates
{
    public class Flower : GameObject
    {
        public Flower(int dstX, int dstY)
        {
            location.X = dstX;
            location.Y = dstY;
            size = new Point(60, 40);
            sprite = SpriteFactory.Instance.CreateSprite("flower");
        }
    }
}
