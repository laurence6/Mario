using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MarioPirates
{
    public class Block : ISprite
    {
        public BlockState State;

        public Rectangle src, dst;
        public bool hidden = false;

        public Block(int dstX, int dstY)
        {
            State = new Brick5(this);
            dst.X = dstX;
            dst.Y = dstY;
        }

        public void Update()
        {
            State.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Dictionary<string, Texture2D> textures)
        {
            if (!hidden)
                State.Draw(spriteBatch, textures);
        }
    }

}

