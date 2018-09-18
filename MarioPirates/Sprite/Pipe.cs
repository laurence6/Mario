using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MarioPirates
{
    class Pipe : ISprite
    {
        private Rectangle src, dest;
        private const int pipeWidth = 64, pipeHeight = 46, zoom = 2;
        
        public Pipe(int destX, int destY)
        {
            src = new Rectangle(0, 0, pipeWidth, pipeHeight);
            dest = new Rectangle(destX, destY, pipeWidth  * zoom, pipeHeight * zoom);
        }

        public void Update()
        {
        }

        public void Draw(SpriteBatch spriteBatch, Dictionary<string, Texture2D> textures)
        {
            spriteBatch.Draw(textures["pipeline"], dest, src, Color.White);
        }
    }
}
