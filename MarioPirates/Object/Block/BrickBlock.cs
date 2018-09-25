using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioPirates
{
    class BrickBlock : BlockState
    {
        public BrickBlock(Block block) : base(block)
        {
            block.sprite = SpriteFactory.Instance.CreateSprite("brickblock");
        }

        public override void ChangeToBrickBlock()
        {
        }
    }
}
