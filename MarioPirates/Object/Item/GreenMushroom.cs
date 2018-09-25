using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal class GreenMushroom : GameObject
    {
        private const int greenMushroomWidth = 30, greenMushroomHeight = 24;
        public GreenMushroom(int dstX, int dstY)
        {
            Location.X = dstX;
            Location.Y = dstY;
            Size = new Point(greenMushroomWidth * 2, greenMushroomHeight * 2);
            Sprite = SpriteFactory.Instance.CreateSprite("greenmushroom");
        }
    }
}
