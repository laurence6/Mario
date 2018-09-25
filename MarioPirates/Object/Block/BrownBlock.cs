using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MarioPirates
{

    public class BrownBlock : BlockState
    {
        public BrownBlock(Block block) : base(block)
        {
            block.sprite = SpriteFactory.Instance.CreateSprite("brownblock");
        }

        public override void ChangeToBrownBlock()
        {
        }
    }

}
