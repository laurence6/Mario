using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MarioPirates.Sprite
{
    class Blocks : ISprite
    {
        // blocks, blocks4, brick1, brick2, brick3
        protected const int blockHeight = 16, blockWidth = 16, zoom = 4;

        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch, Dictionary<string, Texture2D> textures)
        {

        }

        public abstract class BlockState
        {

        }


    }
}
