using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal class Bushes : GameObject
    {
        private const int bushesWidth = 100, bushesHeight = 17;

        public Bushes(int dstX, int dstY)
        {
            location.X = dstX;
            location.Y = dstY;
            size = new Point(bushesWidth, bushesHeight);
            Sprite = SpriteFactory.CreateSprite("bushes");
        }
    }
}
