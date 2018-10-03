using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal class RedMushroom : GameObject
    {
        private const int redMushroomWidth = 16, redMushroomHeight = 16;
        public RedMushroom(int dstX, int dstY)
        {
            location.X = dstX;
            location.Y = dstY;
            size = new Point(redMushroomWidth * 2, redMushroomHeight * 2);
            Sprite = SpriteFactory.Instance.CreateSprite("redmushroom");
        }
    }
}
