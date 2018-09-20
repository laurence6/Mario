using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MarioPirates
{

    public class MarioStateDead : MarioState
    {
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

        public override void Dead()
        {
        }

        public override void Update()
        {
            mario.DrawSrc.X = 0;
            mario.DrawSrc.Y = 0;
            mario.DrawSrc.Width = deadMarioWidth;
            mario.DrawSrc.Height = deadMarioHeight;
            mario.DrawDst.Width = deadMarioWidth * zoom;
            mario.DrawDst.Height = deadMarioHeight * zoom;
        }

        public override void Draw(SpriteBatch spriteBatch, Dictionary<string, Texture2D> textures)
        {
            spriteBatch.Draw(textures["deadmario"], mario.DrawDst, mario.DrawSrc, Color.White);
        }
    }

}
