using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal class MarioStateSmall : MarioStateSize
    {
        public const int marioWidth = 34, marioHeight = 30;

        public MarioStateSmall(MarioState state) : base(state)
        {
            state.mario.Size = new Point(marioWidth, marioHeight);
        }

        public override void Small()
        {
        }

        public override void Big()
        {
            base.Big();
            state.mario.Location =
                new Vector2(
                state.mario.Location.X - (marioWidth - MarioStateBig.marioWidth) / 2,
                state.mario.Location.Y + marioHeight - MarioStateBig.marioHeight);
        }

        public override void Fire()
        {
            base.Fire();
            state.mario.Location =
                new Vector2(
                state.mario.Location.X - (marioWidth - MarioStateFire.marioWidth) / 2,
                state.mario.Location.Y + marioHeight - MarioStateFire.marioHeight);
        }
        public override MarioStateEnum State => MarioStateEnum.Small;
    }
}
