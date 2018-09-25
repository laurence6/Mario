using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MarioPirates
{

    public abstract class BlockState
    {
        protected Block block;

        protected BlockState(Block block)
        {
            this.block = block;
        }

        public virtual void ChangeToBrickBlock()
        {
            block.State = new BrickBlock(block);
        }

        public virtual void ChangeToBrownBlock()
        {
            block.State = new BrownBlock(block);
        }

        public virtual void ChangeToQuestionBlock()
        {
            block.State = new QuestionBlock(block);
        }

        public virtual void ChangeToBrokenBlock()
        {
            block.State = new BrokenBlock(block);
        }

        public virtual void ChangeToOrangeBlock()
        {
            block.State = new OrangeBlock(block);
        }
    }
}
