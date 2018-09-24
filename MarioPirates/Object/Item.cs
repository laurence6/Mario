using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MarioPirates
{
    public abstract class Item : ISprite
    {
        public int itemHeight = 20, itemWidth = 30, zoom = 3;
        public int textureFrameCount = 4, framesPerSprite = 15;

        public Rectangle src, dst;

        public int frameCount = 0;

        public Item(int dstX, int dstY)
        {
            dst.X = dstX;
            dst.Y = dstY;

            src = new Rectangle(0, 0, itemWidth, itemHeight);
            dst = new Rectangle(dst.X, dst.Y, itemWidth * zoom, itemHeight * zoom);
        }

        public virtual void Update()
        {
            if (frameCount++ / framesPerSprite >= 4)
            {
                frameCount = 0;
            }
            if (frameCount % framesPerSprite == 0)
            {
                src.X = itemWidth * frameCount / framesPerSprite;
            }
        }

        public abstract void Draw(SpriteBatch spriteBatch, Dictionary<string, Texture2D> textures);
    }
}
