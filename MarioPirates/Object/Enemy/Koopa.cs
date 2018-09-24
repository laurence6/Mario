using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MarioPirates
{

    class Koopa : ISprite
    {
        private const int screenWidth = 800, screenHeight = 480;
        private const int koopaWidth = 30, koopaHeight = 24, zoom = 3;
        private const int textureFrameCount = 9;

        private const int framesPerSprite = 15;

        private enum State { normal, flipped, stomped };
       
        private State state = State.normal;
        private Direction direction;
        protected Rectangle dst = new Rectangle(0, 0, koopaWidth * zoom, koopaHeight * zoom);
        protected Rectangle src = new Rectangle(0, 0, koopaWidth, koopaHeight);

        private int frameCount = 0;

        public Koopa(int x, int y, Direction dir)
        {
            dst.X = x;
            dst.Y = y;
            direction = dir;
        }

        public void Update()
        {
            if (state == State.normal)
            {
                if (direction == Direction.left)
                {
                    if (frameCount++ % framesPerSprite == 0)
                    {
                        switch (frameCount / framesPerSprite)
                        {
                            case 0:
                                src.X = 60;
                                src.Y = 0;
                                break;
                            case 1:
                                src.X = 30;
                                src.Y = 0;
                                break;
                            case 2:
                                src.X = 0;
                                src.Y = 0;
                                break;
                            case 3:
                                frameCount = 0;

                                break;
                        }
                    }
                    if (dst.X-- == 0)
                    {
                        direction = Direction.right;
                    }
                }
                else
                {
                    if (frameCount++ % framesPerSprite == 0)
                    {
                        switch (frameCount / framesPerSprite)
                        {
                            case 0:
                                src.X = 90;
                                src.Y = 0;
                                break;
                            case 1:
                                src.X = 120;
                                src.Y = 0;
                                break;
                            case 2:
                                src.X = 150;
                                src.Y = 0;
                                break;
                            case 3:
                                frameCount = 0;
                                break;
                        }

                    }
                    if (dst.X++ == 752)
                    {
                        direction = Direction.left;
                    }
                }

            }
            else if (state == State.stomped)
            {
                if (frameCount % framesPerSprite == 0)
                {
                    switch (frameCount / framesPerSprite)
                    {
                        case 0:
                            src.X = 210;
                            src.Y = 0;
                            break;
                        case 1:
                            src.X = 240;
                            src.Y = 0;
                            break;                    
                    }
                    frameCount++;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, Dictionary<string, Texture2D> textures, Rectangle dest)
        {
            spriteBatch.Draw(textures["turtles"], dst, src, Color.White);
        }
    }
}


