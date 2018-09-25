using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MarioPirates
{
    class GreenMushroom : GameObject
    {
        public GreenMushroom(int dstX, int dstY)
        {
            location.X = dstX;
            location.Y = dstY;
            size = new Point(size.X * 2, size.Y * 2);
            sprite = SpriteFactory.Instance.CreateSprite("greenmushroom");
        }
    }
}
