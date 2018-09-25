using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MarioPirates
{
    public class Coin : GameObject
    {
        private const int coinWidth = 30, coinHeight = 24;
        public Coin(int dstX, int dstY)
        {
            location.X = dstX;
            location.Y = dstY;
            size = new Point(coinWidth * 2, coinHeight * 2);
            sprite = SpriteFactory.Instance.CreateSprite("coin");
        }
    }
}
