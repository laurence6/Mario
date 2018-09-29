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

        private float elpased = 0;

        public Sprite(string textureName, Point size, params Point[] frames)
        {
            this.textureName = textureName;
            this.size = size;
            this.frames = frames;
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
                    new Rectangle(frames[(int)(elpased / frameUpdateInterval) % frames.Length], size),
                    Color.White);
            }
        }
    }
}

