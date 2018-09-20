using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MarioPirates
{
    public class Flower : ISprite
    {
        private const int flowerHeight = 20, flowerWidth = 30, zoom = 3;
        private const int textureFrameCount = 4, framesPerSprite = 15;

        private Rectangle src, dst;

        private int frameCount = 0;

        public Flower(int dstX, int dstY)
        {
            src = new Rectangle(0, 0, flowerWidth, flowerHeight);
            dst = new Rectangle(dstX, dstY, flowerWidth * zoom, flowerHeight * zoom);
        }

        public void Update()
        {
            if (frameCount++ / framesPerSprite >= 4)
            {
                frameCount = 0;
            }
            if (frameCount % framesPerSprite == 0)
            {
                src.X = flowerWidth * frameCount / framesPerSprite;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Dictionary<string, Texture2D> textures)
        {
            spriteBatch.Draw(textures["flower"], dst, src, Color.White);
        }
    }
}
