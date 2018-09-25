using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MarioPirates
{
    public class Sprite
    {
        private const uint frameUpdateInterval = 15;

        private string textureName;
        private Point size;
        private Point[] frames;

        private uint frameCount = 0;

        public Sprite(string textureName, Point size, params Point[] frames)
        {
            this.textureName = textureName;
            this.size = size;
            this.frames = frames;
        }

        public void Update()
        {
            frameCount++;
        }

        public void Draw(SpriteBatch spriteBatch, Dictionary<string, Texture2D> textures, Rectangle drawDst)
        {
            if (frames.Length > 0 && frameCount % frameUpdateInterval == 0)
            {
                spriteBatch.Draw(
                    textures[textureName],
                    drawDst,
                    new Rectangle(frames[frameCount / frameUpdateInterval % frames.Length], size),
                    Color.White);
            }
        }
    }
}

