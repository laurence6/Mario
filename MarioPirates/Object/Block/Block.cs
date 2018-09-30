using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MarioPirates
{
    internal enum BlockState
    {
        Normal, Hidden,
    }

    internal class Block : GameObject
    {
        private const int blockWidth = 16, blockHeight = 16;

        private BlockState state = BlockState.Normal;

        public Block(int dstX, int dstY)
        {
            location.X = dstX;
            location.Y = dstY;
            size = new Point(blockWidth * 2, blockHeight * 2);
        }

        public override void Draw(SpriteBatch spriteBatch, Dictionary<string, Texture2D> textures)
        {
            if (state == BlockState.Normal)
                base.Draw(spriteBatch, textures);
        }

        public void SetHidden(bool hidden)
        {
            state = hidden ? BlockState.Hidden : BlockState.Normal;
        }
    }
}

