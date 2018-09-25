using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MarioPirates
{
    public class Pipe : GameObject
    {
        public Pipe(int dstX, int dstY)
        {
            location.X = dstX;
            location.Y = dstY;
            size = new Point(64, 46);
            sprite = SpriteFactory.Instance.CreateSprite("pipe");
        }
    }
}
