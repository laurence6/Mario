using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MarioPirates
{
    public class Star : ISprite
    {
        private const int starHeight = 24, starWidth = 30, zoom = 3;
        private const int textureFrameCount = 4, framesPerSprite = 15;

        private Rectangle src, dst;

        private int frameCount = 0;

        public Star(int dstX, int dstY)
        {
            src = new Rectangle(0, 0, starWidth, starHeight);
            dst = new Rectangle(dstX, dstY, starWidth * zoom, starHeight * zoom);
        }

        public void Update()
        {
            if (frameCount++ / framesPerSprite >= 4)
            {
                frameCount = 0;
            }
            if (frameCount % framesPerSprite == 0)
            {
                src.X = starWidth * frameCount / framesPerSprite;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Dictionary<string, Texture2D> textures)
        {
            spriteBatch.Draw(textures["stars"], dst, src, Color.White);
        }
    }
}
