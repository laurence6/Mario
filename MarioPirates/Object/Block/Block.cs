using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MarioPirates
{
    public class Block : GameObject
    {
        public BlockState State;
        public bool hidden = false;

        public Block(int dstX, int dstY)
        {
            location.X = dstX;
            location.Y = dstY;
            size = new Point(16, 16);
            sprite = SpriteFactory.Instance.CreateSprite("brick5");

            State = new QuestionBlock(this);
        }

        public override void Update()
        {
            State.Update();
        }
    }

}

