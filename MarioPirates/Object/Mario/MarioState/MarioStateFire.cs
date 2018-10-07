using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal class MarioStateFire : MarioStateSize
    {
        protected const int marioWidth = 32, marioHeight = 64;

        public MarioStateFire(Mario mario) : base(mario)
        {
            mario.Size = new Point(marioWidth, marioHeight);
        }

        public override void Fire()
        {
        }

        public override string GetString()
        {
            return "fire";
        }
    }
}
