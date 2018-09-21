using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MarioPirates
{

    public abstract class MarioStateFire : MarioState
    {
        public const int marioWidth = 26, marioHeight = 31;

        public MarioStateFire(Mario mario) : base(mario)
        {
        }

        public override void Left()
        {
            mario.State = new MarioStateBigLeftIdle(mario);
        }

        public override void Right()
        {
            mario.State = new MarioStateBigRightIdle(mario);
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
