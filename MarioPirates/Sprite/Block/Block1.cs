using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MarioPirates
{

    public class Block1 : BlockState
    {
        public Block1(Block block) : base(block)
        {
        }

        public override void ChangeToBlock1()
        {
        }

        public override void Draw(SpriteBatch spriteBatch, Dictionary<string, Texture2D> textures)
        {
            spriteBatch.Draw(textures["blocks"], block.dst, block.src, Color.White);
        }
    }

}
