using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioPirates
{
    internal class Sprite
    {
        private const float frameUpdateInterval = 15 * 0.016f;

        private Texture2D texture;
        private Point size;
        private Point[] frames;
        private float accelerateRate;

        private float elpased = 0;

        public Sprite(Texture2D texture, Point size, Point[] frames, float accelerateRate)
        {
            this.texture = texture;
            this.size = size;
            this.frames = frames;
            this.accelerateRate = accelerateRate;
        }

        public void Update(float dt)
        {
            elpased += dt;
        }

        public void Draw(SpriteBatch spriteBatch, Rectangle drawDst)
        {
            if (frames.Length > 0)
            {
                spriteBatch.Draw(
                    texture,
                    drawDst,
                    new Rectangle(frames[(int)(elpased / frameUpdateInterval * accelerateRate) % frames.Length], size),
                    Color.White);
            }
        }
    }
}
