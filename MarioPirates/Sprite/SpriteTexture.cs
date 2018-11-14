using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioPirates
{
    internal class SpriteTexture : ISprite
    {
        private Texture2D texture;
        private Point size;
        private Point[] frames;
        private float accelerateRate;

        private float elpased = 0;

        public SpriteTexture(Texture2D texture, Point size, Point[] frames, float accelerateRate)
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
        }

        public void Draw(SpriteBatch spriteBatch, float dstX, float dstY, int? sizeX, int? sizeY)
        {
            if (frames.Length > 0)
            {
                spriteBatch.Draw(
                    texture,
                    new Rectangle((int)dstX, (int)dstY, sizeX.Value, sizeY.Value),
                    new Rectangle(frames[(int)(elpased / Constants.FRAME_UPDATE_INTERVAL * accelerateRate) % frames.Length], size),
                    Color.White);
            }
        }
    }
}
