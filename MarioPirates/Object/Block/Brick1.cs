using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MarioPirates
{

    public class Brick1 : BlockState
    {
        public Brick1(Block block) : base(block)
        {
            block.sprite = SpriteFactory.Instance.CreateSprite("brick1");
        }

        public override void ChangeToBrick1()
        {
        }
    }

}
