using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MarioPirates
{

    public abstract class MarioStateBig : MarioState
    {
        public const int marioWidth = 120, marioHeight = 128;

        protected MarioStateBig(Mario mario, int dstX, int dstY) : base(mario, dstX, dstY)
        {
            new Point(marioHeight, marioWidth);
        }

        public override void Left()
        {
            mario.State = new MarioStateBigLeftIdle(mario, location.X, location.Y);
        }

        public override void Right()
        {
            mario.State = new MarioStateBigRightIdle(mario, location.X, location.Y);
        }

        public override void Update()
        {
            mario.DrawSrc.Width = marioWidth;
            mario.DrawSrc.Height = marioHeight;
            mario.DrawDst.Width = marioWidth * zoom;
            mario.DrawDst.Height = marioHeight * zoom;
        }

        public override void Draw(SpriteBatch spriteBatch, Dictionary<string, Texture2D> textures)
        {
            spriteBatch.Draw(textures["bigmario"], mario.DrawDst, mario.DrawSrc, Color.White);
        }
    }

}
