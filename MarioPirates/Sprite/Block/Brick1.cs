using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MarioPirates
{

    public class Brick1 : BlockState
    {
        public Brick1(Block block) : base(block)
        {
        }

        public override void ChangeToBrick1()
        {
        }

        public override void Draw(SpriteBatch spriteBatch, Dictionary<string, Texture2D> textures)
        {
            spriteBatch.Draw(textures["brick1"], block.dst, block.src, Color.White);
        }
    }

}
