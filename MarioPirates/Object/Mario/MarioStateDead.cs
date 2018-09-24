using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MarioPirates
{

    public class MarioStateDead : MarioState
    {
        public const int marioWidth = 15, marioHeight = 14;

        public MarioStateDead(Mario mario) : base(mario)
        {
        }

        public override void Left()
        {
        }

        public override void Right()
        {
        }

        public override void Jump()
        {
        }

        public override void Crouch()
        {
        }

        public override void Small()
        {
            mario.State = new MarioStateSmallRightIdle(mario);
        }

        public override void Big()
        {
            mario.State = new MarioStateBigRightIdle(mario);
        }

        public override void Fire()
        {
            mario.State = new MarioStateFireRightIdle(mario);
        }

        public override void Dead()
        {
        }

        public override void Update()
        {
            mario.DrawSrc.X = 0;
            mario.DrawSrc.Y = 0;
            mario.DrawSrc.Width = marioWidth;
            mario.DrawSrc.Height = marioHeight;
            mario.DrawDst.Width = marioWidth * zoom;
            mario.DrawDst.Height = marioHeight * zoom;
        }

        public override void Draw(SpriteBatch spriteBatch, Dictionary<string, Texture2D> textures)
        {
            spriteBatch.Draw(textures["deadmario"], mario.DrawDst, mario.DrawSrc, Color.White);
        }
    }

}
