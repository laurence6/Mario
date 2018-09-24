using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MarioPirates
{

    public class Brick2 : BlockState
    {
        public Brick2(Block block) : base(block)
        {
            block.sprite = SpriteFactory.Instance.CreateSprite("brick2");
        }

        public override void ChangeToBrick2()
        {
        }
    }

}
