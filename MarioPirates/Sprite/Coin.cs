using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MarioPirates
{
    public class Coin : ISprite
    {
        private Rectangle src, dest;
        private const int coinHeight = 24, coinWidth = 30, zoom = 3;
        protected const int textureFrameCount = 4, framesPerSprite = 15;
        private int frameCount, frame;

        public Coin(int destX, int destY)
        {
            src = new Rectangle(0, 0, coinWidth, coinHeight);
            dest = new Rectangle(destX, destY, coinWidth * zoom, coinHeight * zoom);

            frameCount = 0;
            frame = 0;
        }

        public void Update()
        {
            if (frameCount++ / framesPerSprite >= 4)
            {
                frameCount = 0;
            }
            if (frameCount % framesPerSprite == 0)
            {
                switch (frameCount / framesPerSprite)
                {
                    case 0:
                        frame = 0;
                        break;
                    case 1:
                        frame = 1;
                        break;
                    case 2:
                        frame = 2;
                        break;
                    case 3:
                        frame = 3;
                        break;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, Dictionary<string, Texture2D> textures)
        {
            src = new Rectangle(coinWidth * frame, 0, coinWidth, coinHeight); 
            spriteBatch.Draw(textures["coins"], dest, src, Color.White);
        }
    }
}
