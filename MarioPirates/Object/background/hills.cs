using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal class Hills : GameObject
    {

        private const int hillsWidth = 135, hillsHeight = 40;
        public Hills(int dstX, int dstY)
        {
            location.X = dstX;
            location.Y = dstY;
            size = new Point(hillsWidth, hillsHeight);
            Sprite = SpriteFactory.CreateSprite("hills");
        }


    }
}
