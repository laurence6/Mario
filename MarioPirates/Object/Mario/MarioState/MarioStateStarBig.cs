using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal abstract class MarioStateStarBig : MarioState
    {
        protected const int marioWidth = 64, marioHeight = 128;

        protected MarioStateStarBig(Mario mario) : base(mario)
        {
            mario.Size = new Point(marioWidth, marioHeight);
        }

        public override void Small()
        {
        }

        public override void Big()
        {
        }

        public override void Fire()
        {
        }

        public override void Star()
        {
        }

        public override void Dead()
        {
            mario.State = new MarioStateStarDead(mario);
        }
    }
}
