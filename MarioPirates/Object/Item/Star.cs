using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MarioPirates
{
    public class Star : GameObject
    {
        public Star(int dstX, int dstY)
        {
            location.X = dstX;
            location.Y = dstY;
            size = new Point(60, 40);
            sprite = SpriteFactory.Instance.CreateSprite("stars");
        }
    }
}
