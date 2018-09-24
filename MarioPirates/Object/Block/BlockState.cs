using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MarioPirates
{

    public abstract class BlockState
    {
        public const int blockWidth = 16, blockHeight = 16, zoom = 2;

        protected Block block;

        protected BlockState(Block block)
        {
            this.block = block;
            block.src = new Rectangle(0, 0, blockWidth, blockHeight);
            block.dst = new Rectangle(block.dst.X, block.dst.Y, blockWidth * zoom, blockHeight * zoom);
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

        public abstract void Draw(SpriteBatch spriteBatch, Dictionary<string, Texture2D> textures);
    }

}
