using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal class MarioStateSmall : MarioStateSize
    {
        protected const int marioWidth = 34, marioHeight = 30;

        public MarioStateSmall(MarioState state) : base(state)
        {
            state.mario.Size = new Point(marioWidth, marioHeight);
        }

        public override void Small()
        {
        }

        public override MarioStateEnum State => MarioStateEnum.Small;
    }
}