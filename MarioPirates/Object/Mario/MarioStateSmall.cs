using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MarioPirates
{

    public abstract class MarioStateSmall : MarioState
    {
        public const int marioWidth = 30, marioHeight = 15;

        public MarioStateSmall(Mario mario) : base(mario)
        {
        }

        public override void Left()
        {
            mario.State = new MarioStateSmallLeftIdle(mario);
        }

        public override void Right()
        {
            mario.State = new MarioStateSmallRightIdle(mario);
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
            spriteBatch.Draw(textures["smallmario"], mario.DrawDst, mario.DrawSrc, Color.White);
        }
    }

}
