using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MarioPirates
{
    public class RedMushroom : ISprite
    {
        private const int coinHeight = 30, coinWidth = 28, zoom = 3;

        private Rectangle src, dst;

        public RedMushroom(int destX, int destY)
        {
            src = new Rectangle(0, 0, coinWidth, coinHeight);
            dst = new Rectangle(destX, destY, coinWidth * zoom, coinHeight * zoom);
        }

        public void Update()
        {
        }

        public void Draw(SpriteBatch spriteBatch, Dictionary<string, Texture2D> textures)
        {
            spriteBatch.Draw(textures["redmushroom"], dst, src, Color.White);
        }
    }
}
