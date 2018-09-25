using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MarioPirates
{
    public class Goomba : ISprite
    {
        private const int screenWidth = 800, screenHeight = 480;
        private const int goombaWidth = 30, goombaHeight = 20, zoom = 3;
        private const int textureFrameCount = 3;

        private const int framesPerSprite = 15;

        private enum State { normal, flipped, stomped };

        private State state = State.normal;

        protected Rectangle dst = new Rectangle(0, 0, goombaWidth * zoom, goombaHeight * zoom);
        protected Rectangle src = new Rectangle(0, 0, goombaWidth, goombaHeight);

        private int frameCount = 0;
        private int vx = 1;

        public Goomba(int x, int y)
        {
            dst.X = x;
            dst.Y = y;
        }

        public void Update()
        {
            if (state == State.normal)
            {
                if (frameCount++ / framesPerSprite >= 2)
                {
                    frameCount = 0;
                }

                if (frameCount % framesPerSprite == 0)
                {
                    switch (frameCount / framesPerSprite)
                    {
                        case 0:
                            src.X = 0;
                            src.Y = 0;
                            break;
                        case 1:
                            src.X = 30;
                            src.Y = 0;
                            break;
                    }
                }
            }

            vx = (dst.X == 0) ? 1 : (dst.X == screenWidth - 48) ? -1 : vx;
            dst.X += vx;
        }

        public void Draw(SpriteBatch spriteBatch, Dictionary<string, Texture2D> textures)
        {
            spriteBatch.Draw(textures["goomba"], dst, src, Color.White);
        }
    }
}
