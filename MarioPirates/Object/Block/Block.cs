using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MarioPirates
{
    public class Block : GameObject
    {
        public BlockState State;
        public bool hidden = false;

        private const int blockWidth = 16, blockHeight = 16;

        public Block(int dstX, int dstY)
        {
            location.X = dstX;
            location.Y = dstY;
            size = new Point(blockWidth * 2, blockHeight * 2);
            sprite = SpriteFactory.Instance.CreateSprite("orangeblock");

            State = new OrangeBlock(this);
        }

        public override void Update()
        {
            State.Update();
        }
    }

}

