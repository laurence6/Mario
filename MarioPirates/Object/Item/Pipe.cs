using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MarioPirates
{
    public class Pipe : GameObject
    {
        private const int pipeWidth = 64, pipeHeight = 46;
        public Pipe(int dstX, int dstY)
        {
            location.X = dstX;
            location.Y = dstY;
            size = new Point(pipeWidth * 2, pipeHeight * 2);
            sprite = SpriteFactory.Instance.CreateSprite("pipe");
        }
    }
}
