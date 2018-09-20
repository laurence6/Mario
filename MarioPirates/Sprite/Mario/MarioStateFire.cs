using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MarioPirates
{

    public class MarioStateFire : MarioState
    {
        public MarioStateFire(Mario mario) : base(mario)
        {
        }

        public override void Fire()
        {
        }

        public override void Update()
        {
            mario.DrawSrc.X = 180;
            mario.DrawSrc.Y = 0;
            mario.DrawSrc.Width = bigMarioWidth;
            mario.DrawSrc.Height = bigMarioHeight;
            mario.DrawDst.Width = bigMarioWidth * zoom;
            mario.DrawDst.Height = bigMarioHeight * zoom;
        }

        public override void Draw(SpriteBatch spriteBatch, Dictionary<string, Texture2D> textures)
        {
            spriteBatch.Draw(textures["biggermario"], mario.DrawDst, mario.DrawSrc, Color.White);
        }
    }

}
