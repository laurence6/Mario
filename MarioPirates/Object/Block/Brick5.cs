using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MarioPirates
{

    public class Brick5 : BlockState
    {
        public Brick5(Block block) : base(block)
        {
        }

        public override void ChangeToBlock1()
        {
        }

        public override void Draw(SpriteBatch spriteBatch, Dictionary<string, Texture2D> textures)
        {
            spriteBatch.Draw(textures["brick5"], block.dst, block.src, Color.White);
        }
    }

}
