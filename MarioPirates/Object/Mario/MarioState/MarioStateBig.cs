using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal class MarioStateBig : MarioStateSize
    {
        protected const int marioWidth = 32, marioHeight = 64;

        public MarioStateBig(MarioState state) : base(state)
        {
            state.mario.Size = new Point(marioWidth, marioHeight);
        }

        public override void Big()
        {
        }

        public override MarioStateEnum State => MarioStateEnum.Big;
    }
}
