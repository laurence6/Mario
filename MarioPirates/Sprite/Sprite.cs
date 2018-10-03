using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MarioPirates
{
    internal class Sprite
    {
        private const float frameUpdateInterval = 15 * 0.016f;

        private string textureName;
        private Point size;
        private Point[] frames;
        private float accelerateRate;

        private float elpased = 0;

        public Sprite(string textureName, Point size, params Point[] frames)
        {
            this.textureName = textureName;
            this.size = size;
            this.frames = frames;
            accelerateRate = 1;
        }

        public Sprite(string textureName, float accelerateRate, Point size, params Point[] frames)
        {
            this.textureName = textureName;
            this.size = size;
            this.frames = frames;
            this.accelerateRate = accelerateRate;
        }

        public void Update(float dt)
        {
            elpased += dt;
        }

        public void Draw(SpriteBatch spriteBatch, Dictionary<string, Texture2D> textures, Rectangle drawDst)
        {
            if (frames.Length > 0)
            {
                spriteBatch.Draw(
                    textures[textureName],
                    drawDst,
                    new Rectangle(frames[(int)(elpased / frameUpdateInterval * accelerateRate) % frames.Length], size),
                    Color.White);
                spriteBatch.Draw(
                    textures["frame"],
                    drawDst,
                    new Rectangle(0, 0, 16, 16),
                    Color.White);
            }
        }
    }
}
