using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MarioPirates
{ 
    public class BrokenBlock : BlockState
    {
        public BrokenBlock(Block block) : base(block)
        {
            block.sprite = SpriteFactory.Instance.CreateSprite("brokenblock");
        }

        public override void ChangeToBrokenBlock()
        {
        }
    }

}
