using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioPirates
{
    class Brick5 : BlockState
    {
        public Brick5(Block block) : base(block)
        {
            block.sprite = SpriteFactory.Instance.CreateSprite("brick5");
        }

        public override void ChangeToBrick5()
        {
        }
    }
}
