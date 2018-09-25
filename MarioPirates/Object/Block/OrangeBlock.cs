using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MarioPirates
{

    public class OrangeBlock : BlockState
    {
        public OrangeBlock(Block block) : base(block)
        {
            block.sprite = SpriteFactory.Instance.CreateSprite("orangeblock");
        }

        public override void ChangeToOrangeBlock()
        {
        }
    }

}
