using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MarioPirates
{
    public abstract class MarioState
    {
        public const int marioWidth = 30, marioHeight = 15;
        public const int bigMarioWidth = 30, bigMarioHeight = 32;
        public const int deadMarioWidth = 15, deadMarioHeight = 14;
        public const int zoom = 4;

        protected Mario mario;

        protected MarioState(Mario mario)
        {
            this.mario = mario;
        }

        public virtual void Left()
        {
            mario.State = new MarioStateLeftIdle(mario);
        }

        public virtual void Right()
        {
            mario.State = new MarioStateRightIdle(mario);
        }

        public virtual void Jump()
        {
            mario.State = new MarioStateRightJump(mario);
        }

        public virtual void Crouch()
        {
            mario.State = new MarioStateRightCrouch(mario);
        }

        public virtual void Small()
        {
            mario.State = new MarioStateSmall(mario);
        }

        public virtual void Big()
        {
            mario.State = new MarioStateBig(mario);
        }

        public virtual void Fire()
        {
            mario.State = new MarioStateFire(mario);
        }

        public virtual void Dead()
        {
            mario.State = new MarioStateDead(mario);
        }

        public abstract void Update();

        public virtual void Draw(SpriteBatch spriteBatch, Dictionary<string, Texture2D> textures)
        {
            spriteBatch.Draw(textures["mario"], mario.DrawDst, mario.DrawSrc, Color.White);
        }
    }
}
