using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MarioPirates
{

    public class Brick2 : BlockState
    {
        public Brick2(Block block) : base(block)
        {
        }

        public override void ChangeToBrick2()
        {
        }

        public override void Draw(SpriteBatch spriteBatch, Dictionary<string, Texture2D> textures)
        {
            spriteBatch.Draw(textures["brick2"], block.dst, block.src, Color.White);
        }
    }

}
