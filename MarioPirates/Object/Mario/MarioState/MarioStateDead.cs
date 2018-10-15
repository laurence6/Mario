using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal class MarioStateDead : MarioStateSize
    {
        protected const int marioWidth = 30, marioHeight = 28;

        public MarioStateDead(MarioState state) : base(state)
        {
            state.mario.Size = new Point(marioWidth, marioHeight);
        }

        public override void Dead()
        {
        }

        public override bool IsDead => true;

        public override MarioStateEnum State => MarioStateEnum.Dead;
    }
}
