using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal class RedMushroom : GameObject
    {
        private const int redMushroomWidth = 16, redMushroomHeight = 16;
        public RedMushroom(int dstX, int dstY)
        {
            Location.X = dstX;
            Location.Y = dstY;
            Size = new Point(redMushroomWidth * 2, redMushroomHeight * 2);
            Sprite = SpriteFactory.Instance.CreateSprite("redmushroom");
        }
    }
}
