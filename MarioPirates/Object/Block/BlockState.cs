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

        public virtual void ChangeToBrick5()
        {
            block.State = new Brick5(block);
        }

        public virtual void ChangeToBrick4()
        {
            block.State = new Brick4(block);
        }

        public virtual void ChangeToBrick1()
        {
            block.State = new Brick1(block);
        }

        public virtual void ChangeToBrick2()
        {
            block.State = new Brick2(block);
        }

        public virtual void ChangeToBrick3()
        {
            block.State = new Brick3(block);
        }

        public virtual void SetHide(bool hidden)
        {
            block.hidden = hidden;
        }

        public virtual void Update()
        {
        }
    }

}
