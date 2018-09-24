using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioPirates
{
    class HiddenBlock : BlockState
    {
        public HiddenBlock(Block block) : base(block)
        {
            block.sprite = SpriteFactory.Instance.CreateSprite(null);
        }
    }
}
