using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal class GreenMushroom : GameObject
    {
        private const int greenMushroomWidth = 16, greenMushroomHeight = 16;
        public GreenMushroom(int dstX, int dstY)
        {
            location.X = dstX;
            location.Y = dstY;
            size = new Point(greenMushroomWidth * 2, greenMushroomHeight * 2);
            Sprite = SpriteFactory.CreateSprite("greenmushroom");
        }
    }
}
