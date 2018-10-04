using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal abstract class MarioStateStarSmall : MarioState
    {
        protected const int marioWidth = 32, marioHeight = 32;

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
