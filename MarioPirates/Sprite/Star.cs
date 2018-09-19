using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MarioPirates
{
    public class Star : ISprite
    {
        private Rectangle src, dest;
        private const int starHeight = 24, starWidth = 30, zoom = 3;
        protected const int textureFrameCount = 4, framesPerSprite = 15;
        private int frameCount, frame;

        public Star(int destX, int destY)
        {
            src = new Rectangle(0, 0, starWidth, starHeight);
            dest = new Rectangle(destX, destY, starWidth * zoom, starHeight * zoom);

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
            src = new Rectangle(starWidth * frame, 0, starWidth, starHeight);
            spriteBatch.Draw(textures["stars"], dest, src, Color.White);
        }
    }
}
