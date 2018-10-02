using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal abstract class MarioStateStarSmall : MarioState
    {
        protected const int marioWidth = 64, marioHeight = 64;

        protected MarioStateStarSmall(Mario mario) : base(mario)
        {
            mario.Size = new Point(marioWidth, marioHeight);
        }

        public override void Small()
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
