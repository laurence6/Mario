using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MarioPirates
{
    public abstract class MarioState
    {
        public const int zoom = 4;

        protected Mario mario;

        protected MarioState(Mario mario, int dstX, int dstY)
        {
            this.mario = mario;
            location.X = dstX;
            location.Y = dstY;
        }

        public abstract void Left();

        public abstract void Right();

        public abstract void Jump();

        public abstract void Crouch();

        public abstract void Small();

        public abstract void Big();

        public abstract void Fire();

        public virtual void Dead()
        {
            mario.State = new MarioStateDead(mario);
        }

        public abstract void Update();

        public abstract void Draw(SpriteBatch spriteBatch, Dictionary<string, Texture2D> textures);
    }
}
