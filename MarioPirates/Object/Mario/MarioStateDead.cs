using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MarioPirates
{

    public class MarioStateDead : MarioState
    {
        public const int marioWidth = 60, marioHeight = 56;

        public MarioStateDead(Mario mario, int dstX, int dstY) : base(mario, dstX, dstY)
        {
            new Point(marioHeight, marioWidth);
            mario.State = SpriteFactory.Instance.CreateSprite("mario_dead");
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
            mario.State = new MarioStateSmallRightIdle(mario, location.X, location.Y);
        }

        public override void Big()
        {
            mario.State = new MarioStateBigRightIdle(mario, location.X, location.Y);
        }

        public override void Fire()
        {
            mario.State = new MarioStateFireRightIdle(mario, location.X, location.Y);
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
