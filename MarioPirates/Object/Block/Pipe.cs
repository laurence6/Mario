using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MarioPirates
{
    public class Pipe : ISprite
    {
        private const int pipeWidth = 64, pipeHeight = 46, zoom = 2;

        private Rectangle src, dst;

        public Pipe(int dstX, int dstY)
        {
            src = new Rectangle(0, 0, pipeWidth, pipeHeight);
            dst = new Rectangle(dstX, dstY, pipeWidth * zoom, pipeHeight * zoom);
        }

        public void Update()
        {
        }

        public void Draw(SpriteBatch spriteBatch, Dictionary<string, Texture2D> textures)
        {
            spriteBatch.Draw(textures["pipeline"], dst, src, Color.White);
        }
    }
}
