
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace MarioPirates

{
    public class GoombaSprite : ISprite
    {
        public GoombaSprite(int locationX, int locationY)
        {
            dst.X = locationX;
            dst.Y = locationY;
        }

        private const int screenWidth = 800, screenHeight = 480;
        private const int goombaWidth = 30, goombaHeight = 20, zoom = 3;
        protected const int textureFrameCount = 3;
        protected int frameCount = 0;
        protected const short framesPerSprite = 15;
        private enum Status { normal, flipped, stomped };
        private enum Direction { left, right };
        private Direction direction = Direction.right;
        private Status status = Status.normal;
        protected Rectangle dst = new Rectangle(
            0, 0,
            goombaWidth * zoom, goombaHeight * zoom);
        protected Rectangle src = new Rectangle(0, 0, goombaWidth, goombaHeight);
        //easier to handle collisions in Enemy classes
        //I think The SAT (Sepearate axis theorem) would be a good way to implement

        private void CheckForCollisions()
        {

        }

        public void Update()
        {
            if (status == Status.normal)
            {
                if (frameCount == 0)
                {
                    src.X = 0;
                    src.Y = 0;
                }
                else if (frameCount == framesPerSprite)
                {
                    src.X = 30;
                    src.Y = 0;
                }
                frameCount++;
                if (direction == Direction.right)
                {
                    dst.X++;
                }
                else
                {
                    dst.X--;
                }
                if (dst.X == 0)
                {
                    direction = Direction.right;
                }
                else if (dst.X == 752)
                {
                    direction = Direction.left;
                }
                if (frameCount >= framesPerSprite * 2)
                {
                    frameCount = 0;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, Dictionary<string, Texture2D> textures)
        {
            spriteBatch.Draw(textures["goomba"], dst, src, Color.White);
        }
    }
}

