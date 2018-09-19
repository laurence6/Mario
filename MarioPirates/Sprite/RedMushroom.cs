using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MarioPirates
{
    public class RedMushroom : ISprite
    {
        private Rectangle src, dest;
        private const int coinHeight = 30, coinWidth = 28, zoom = 3;

        public RedMushroom(int destX, int destY)
        {
            src = new Rectangle(0, 0, coinWidth, coinHeight);
            dest = new Rectangle(destX, destY, coinWidth * zoom, coinHeight * zoom);
        }

        public void Update()
        {
        }

        public void Draw(SpriteBatch spriteBatch, Dictionary<string, Texture2D> textures)
        {
            spriteBatch.Draw(textures["redmushroom"], dest, src, Color.White);
        }
    }

}
