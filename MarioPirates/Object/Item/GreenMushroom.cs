using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal class GreenMushroom : GameObject
    {
        private const int greenMushroomWidth = 30, greenMushroomHeight = 24;
        public GreenMushroom(int dstX, int dstY)
        {
            location.X = dstX;
            location.Y = dstY;
            size = new Point(greenMushroomWidth * 2, greenMushroomHeight * 2);
            sprite = SpriteFactory.Instance.CreateSprite("greenmushroom");
        }
    }
}
