using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MarioPirates
{
    public class RedMushroom : GameObject
    {
        private const int redMushroomWidth = 30, redMushroomHeight = 24;
        public RedMushroom(int dstX, int dstY)
        {
            location.X = dstX;
            location.Y = dstY;
            size = new Point(redMushroomWidth * 2, redMushroomHeight * 2);
            sprite = SpriteFactory.Instance.CreateSprite("redmushroom");
        }
    }
}
