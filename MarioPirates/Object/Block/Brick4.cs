using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MarioPirates
{

    public class Brick4 : BlockState
    {
        public Brick4(Block block) : base(block)
        {
            block.sprite = SpriteFactory.Instance.CreateSprite("brick4");
        }

        public override void ChangeToBrick4()
        {
        }
    }

}
