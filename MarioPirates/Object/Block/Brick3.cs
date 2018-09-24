using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MarioPirates
{

    public class Brick3 : BlockState
    {
        public Brick3(Block block) : base(block)
        {
            block.sprite = SpriteFactory.Instance.CreateSprite("brick3");
        }

        public override void ChangeToBrick3()
        {
        }
    }

}
