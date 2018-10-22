using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal class MarioStateBig : MarioStateSize
    {
        public const int marioWidth = 32, marioHeight = 64;

        public MarioStateBig(MarioState state) : base(state)
        {
            state.mario.Size = new Point(marioWidth, marioHeight);
        }

        public override void Big()
        {
        }

        public override void Small()
        {
            base.Small();
            state.mario.Location = 
                new Vector2(
                state.mario.Location.X - (marioWidth - MarioStateSmall.marioWidth) / 2, 
                state.mario.Location.Y + marioHeight - MarioStateSmall.marioHeight);
        }

        public override void Dead()
        {
            base.Dead();
            state.mario.Location =
                new Vector2(
                state.mario.Location.X - (marioWidth - MarioStateDead.marioWidth) / 2,
                state.mario.Location.Y + marioHeight - MarioStateDead.marioHeight);
        }

        public override MarioStateEnum State => MarioStateEnum.Big;
    }
}
