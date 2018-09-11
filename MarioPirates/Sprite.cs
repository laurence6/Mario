﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioPirates
{
    public interface ISprite
    {
        void Update();

        void Draw(SpriteBatch spriteBatch, Texture2D texture);
    }

    public class MarioSprite : ISprite
    {
        public enum State
        {
            Idle,
        }

        private State state = State.Idle;

        private const int screenWidth = 800, screenHeight = 480;
        private const int marioWidth = 30, marioHeight = 27, zoom = 4;
        private const int textureFrameCount = 4;

        private Rectangle dst = new Rectangle(
            (screenWidth - marioWidth * zoom) / 2,
            (screenHeight - marioHeight * zoom) / 2,
            marioWidth * zoom, marioHeight * zoom);
        private Rectangle src = new Rectangle(0, 0, marioWidth, marioHeight);

        private uint frameCount = 0;

        public void Update()
        {
            frameCount++;
            switch (state)
            {
                case State.Idle:
                    break;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D texture)
        {
            spriteBatch.Draw(texture, dst, src, Color.White);
        }

        public void TransitState(State newState)
        {
            state = newState;
        }
    }

    public abstract class EnemySprite
    {

    }

    public class GoombaSprite : EnemySprite, ISprite
    {
        // easier to handle collisions in Enemy classes
        // I think The SAT (Sepearate axis theorem) would be a good way to implement
        private void CheckForCollisions()
        {

        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch, Texture2D texture)
        {

        }
    }
}