using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MarioPirates
{

    public abstract class MarioStateFire : MarioState
    {
        public const int marioWidth = 120, marioHeight = 132;

        protected MarioStateFire(Mario mario, int dstX, int dstY) : base(mario, dstX, dstY)
        {
            new Point(marioHeight, marioWidth);
        }

        public override void Left()
        {
            mario.State = new MarioStateFireLeftIdle(mario, location.X, location.Y);
        }

        public override void Right()
        {
            mario.State = new MarioStateFireRightIdle(mario, location.X, location.Y);
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
            spriteBatch.Draw(textures["firemario"], mario.DrawDst, mario.DrawSrc, Color.White);
        }
    }

}
