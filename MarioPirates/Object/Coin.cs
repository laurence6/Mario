using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MarioPirates
{
    public class Coin : ISprite
    {
        private const int coinHeight = 24, coinWidth = 30, zoom = 3;
        private const int textureFrameCount = 4, framesPerSprite = 15;

        private Rectangle src, dst;

        private int frameCount = 0;

        public Coin(int dstX, int dstY)
        {
            src = new Rectangle(0, 0, coinWidth, coinHeight);
            dst = new Rectangle(dstX, dstY, coinWidth * zoom, coinHeight * zoom);
        }

        public void Update()
        {
            if (frameCount++ / framesPerSprite >= 4)
            {
                frameCount = 0;
            }
            if (frameCount % framesPerSprite == 0)
            {
                src.X = coinWidth * frameCount / framesPerSprite;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Dictionary<string, Texture2D> textures)
        {
            spriteBatch.Draw(textures["coins"], dst, src, Color.White);
        }
    }
}
