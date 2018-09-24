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
            size = new Point(30, 28);
            sprite = SpriteFactory.Instance.CreateSprite("greenmushroom");
        }
    }
}
