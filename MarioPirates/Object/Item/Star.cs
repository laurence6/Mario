using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MarioPirates
{
    public class Star : GameObject
    {
        private const int starWidth = 30, starHeight = 24;
        public Star(int dstX, int dstY)
        {
            location.X = dstX;
            location.Y = dstY;
            size = new Point(starWidth * 2, starHeight * 2);
            sprite = SpriteFactory.Instance.CreateSprite("stars");
        }
    }
}
