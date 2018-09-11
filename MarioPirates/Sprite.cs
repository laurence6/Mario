﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioPirates
{
    public interface ISprite
    {
        void Update();

        void Draw(SpriteBatch spriteBatch, Texture2D texture);
    }

    public abstract class MarioSprite
    {
        protected const int screenWidth = 800, screenHeight = 480;
        protected const int marioWidth = 30, marioHeight = 27, zoom = 4;
        protected const int textureFrameCount = 4;

        protected Rectangle dst = new Rectangle(
            (screenWidth - marioWidth * zoom) / 2,
            (screenHeight - marioHeight * zoom) / 2,
            marioWidth * zoom, marioHeight * zoom);
        protected Rectangle src = new Rectangle(0, 0, marioWidth, marioHeight);

        public void Draw(SpriteBatch spriteBatch, Texture2D texture)
        {
            spriteBatch.Draw(texture, dst, src, Color.White);
        }
    }

    public class MarioSpriteW : MarioSprite, ISprite
    {
        public void Update() { }
    }

    public class MarioSpriteE : MarioSprite, ISprite
    {
        private uint frameCount = 0;

        public void Update()
        {
            if (frameCount++ >= 10)
            {
                frameCount = 0;
                src.X += marioWidth;
                if (src.X >= marioWidth * textureFrameCount)
                {
                    src.X = 0;
                }
            }
        }
    }

    public class MarioSpriteR : MarioSprite, ISprite
    {
        public void Update()
        {
            dst.Y = (dst.Y < screenHeight) ? dst.Y + 3 : -marioHeight * zoom;
        }
    }

    public class MarioSpriteT : MarioSprite, ISprite
    {
        private uint frameCount = 0;

        public void Update()
        {
            if (frameCount++ >= 10)
            {
                frameCount = 0;
                src.X += marioWidth;
                if (src.X >= marioWidth * textureFrameCount)
                {
                    src.X = 0;
                }
            }

            dst.X = (dst.X < screenWidth) ? dst.X + 3 : -marioWidth * zoom;
        }
    }

    public class MarioSpriteGettingBigger : MarioSprite, ISprite
    {
        private uint frameCount = 0;
        private int originalX;
        private int originalY;

        public void Update()
        {
            if (frameCount == 0)
            {
                // trivial under current structure
                originalX = dst.X;
                originalY = dst.Y;
            }
            if (frameCount > 120) frameCount = 0;
            if (frameCount == 15 || frameCount == 30)
            {
                dst.X -= dst.Width / 4;
                dst.Y -= dst.Height / 2;
                dst.Width *= 2;
                dst.Height *= 2;
            }
            else if (frameCount == 120)
            {
                dst.Width /= 4;
                dst.Height /= 4;
                dst.X = originalX;
                dst.Y = originalY;
            }
            frameCount++;
        }
    }
    public abstract class EnemySprite
    {

    }
}