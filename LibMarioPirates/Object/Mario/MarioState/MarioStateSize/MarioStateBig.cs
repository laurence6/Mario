using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal class MarioStateBig : MarioStateSize
    {
        public MarioStateBig(MarioState state) : base(state)
        {
            state.mario.Size = new Point(Constants.BIG_MARIO_WIDTH, Constants.BIG_MARIO_HEIGHT);
        }

        public override void TurnBig()
        {
        }

        public override void TurnSmall()
        {
            base.TurnSmall();
            state.mario.Location =
                new Vector2(
                state.mario.Location.X - (Constants.BIG_MARIO_WIDTH - Constants.SMALL_MARIO_WIDTH) / 2,
                state.mario.Location.Y + Constants.BIG_MARIO_HEIGHT - Constants.SMALL_MARIO_HEIGHT);
        }

        public override void TurnDead()
        {
            base.TurnDead();
            state.mario.Location =
                new Vector2(
                state.mario.Location.X - (Constants.BIG_MARIO_WIDTH - Constants.DEAD_MARIO_WIDTH) / 2,
                state.mario.Location.Y + Constants.BIG_MARIO_HEIGHT - Constants.DEAD_MARIO_HEIGHT);
        }

        public override MarioStateEnum State => MarioStateEnum.Big;
    }
}
