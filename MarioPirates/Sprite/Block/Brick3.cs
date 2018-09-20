using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MarioPirates
{

    public class Brick3 : BlockState
    {
        public Brick3(Block block) : base(block)
        {
        }

        public override void ChangeToBrick3()
        {
        }

        public override void Draw(SpriteBatch spriteBatch, Dictionary<string, Texture2D> textures)
        {
            spriteBatch.Draw(textures["brick3"], block.dst, block.src, Color.White);
        }
    }

}
