using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MarioPirates
{

    public class Brick4 : BlockState
    {
        public Brick4(Block block) : base(block)
        {
        }

        public override void ChangeToBrick4()
        {
        }

        public override void Draw(SpriteBatch spriteBatch, Dictionary<string, Texture2D> textures)
        {
            spriteBatch.Draw(textures["brick4"], block.dst, block.src, Color.White);
        }
    }

}
