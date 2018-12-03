using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioPirates
{
    internal class SpriteTexture : ISprite
    {
        private Texture2D texture;
        private Point size;
        private Point[] frames;
        private float depth;
        private float accelerateRate;

        public SpriteTexture(Texture2D texture, Point size, Point[] frames, int depth, float accelerateRate)
        {
            this.texture = texture;
            this.size = size;
            this.frames = frames;
            this.depth = depth * Constants.SPRITE_DEPTH_MUL;
            this.accelerateRate = accelerateRate;
        }

        public void Draw(SpriteBatch spriteBatch, float dstX, float dstY, int? sizeX = null, int? sizeY = null)
        {
            if (frames.Length > 0)
            {
                spriteBatch.Draw(
                    texture,
                    new Rectangle((int)dstX, (int)dstY, sizeX.Value, sizeY.Value),
                    new Rectangle(frames[(int)(Time.Now / Constants.FRAME_UPDATE_INTERVAL * accelerateRate) % frames.Length], size),
                    Color.White,
                    Vector2.Zero.X, Vector2.Zero, SpriteEffects.None,
                    depth
                );
            }
        }
    }
}
