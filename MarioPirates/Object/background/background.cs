using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal class Background : GameObject
    {
        private const int bkgdWidth = 1600, bkgdHeight = 480;
        public Background(int dstX, int dstY)
        {
            location.X = dstX;
            location.Y = dstY;
            size = new Point(bkgdWidth, bkgdHeight);
            Sprite = SpriteFactory.CreateSprite("background");
        }
    }
}
