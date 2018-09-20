using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MarioPirates
{
    public class Block : ISprite
    {
        public BlockState state;

        public Rectangle src, dst;

        public Block(int dstX, int dstY)
        {
            state = new Block1(this);
            dst.X = dstX;
            dst.Y = dstY;
        }

        public void Update()
        {
            state.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Dictionary<string, Texture2D> textures)
        {
            state.Draw(spriteBatch, textures);
        }
    }

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

        public virtual void ChangeToBlock1()
        {
            block.state = new Block1(block);
        }

        public virtual void ChangeToBlocks4()
        {
            block.state = new Blocks4(block);
        }

        public virtual void ChangeToBrick1()
        {
            block.state = new Brick1(block);
        }

        public virtual void ChangeToBrick2()
        {
            block.state = new Brick2(block);
        }

        public virtual void ChangeToBrick3()
        {
            block.state = new Brick3(block);
        }

        public virtual void Update()
        {
        }

        public abstract void Draw(SpriteBatch spriteBatch, Dictionary<string, Texture2D> textures);
    }

    public class Block1 : BlockState
    {
        public Block1(Block block) : base(block)
        {
        }

        public override void ChangeToBlock1()
        {
        }

        public override void Draw(SpriteBatch spriteBatch, Dictionary<string, Texture2D> textures)
        {
            spriteBatch.Draw(textures["blocks"], block.dst, block.src, Color.White);
        }
    }

    public class Blocks4 : BlockState
    {
        public Blocks4(Block block) : base(block)
        {
        }

        public override void ChangeToBlocks4()
        {
        }

        public override void Draw(SpriteBatch spriteBatch, Dictionary<string, Texture2D> textures)
        {
            spriteBatch.Draw(textures["blocks4"], block.dst, block.src, Color.White);
        }
    }

    public class Brick1 : BlockState
    {
        public Brick1(Block block) : base(block)
        {
        }

        public override void ChangeToBrick1()
        {
        }

        public override void Draw(SpriteBatch spriteBatch, Dictionary<string, Texture2D> textures)
        {
            spriteBatch.Draw(textures["brick1"], block.dst, block.src, Color.White);
        }
    }

    public class Brick2 : BlockState
    {
        public Brick2(Block block) : base(block)
        {
        }

        public override void ChangeToBrick2()
        {
        }

        public override void Draw(SpriteBatch spriteBatch, Dictionary<string, Texture2D> textures)
        {
            spriteBatch.Draw(textures["brick2"], block.dst, block.src, Color.White);
        }
    }

    public class Brick3 : BlockState
    {
        public Brick3(Block block) : base(block)
        {
        }

        public override void ChangeToBrick3()
        {
        }

        public override void Draw(SpriteBatch spriteBatch, Dictionary<string, Texture2D> textures)
        {
            spriteBatch.Draw(textures["brick3"], block.dst, block.src, Color.White);
        }
    }
}

