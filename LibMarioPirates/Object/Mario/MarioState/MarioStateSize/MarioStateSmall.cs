using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal class MarioStateSmall : MarioStateSize
    {
        public MarioStateSmall(MarioState state) : base(state)
        {
            state.mario.Size = new Point(Constants.SMALL_MARIO_WIDTH, Constants.SMALL_MARIO_HEIGHT);
        }

        public override void TurnSmall()
        {
        }

        public override void TurnBig()
        {
            base.TurnBig();
            state.mario.Location =
                new Vector2(
                state.mario.Location.X - (Constants.SMALL_MARIO_WIDTH - Constants.BIG_MARIO_WIDTH) / 2,
                state.mario.Location.Y + Constants.SMALL_MARIO_HEIGHT - Constants.BIG_MARIO_HEIGHT);
        }

        public override void TurnFire()
        {
            base.TurnFire();
            state.mario.Location =
                new Vector2(
                state.mario.Location.X - (Constants.SMALL_MARIO_WIDTH - Constants.FIRE_MARIO_WIDTH) / 2,
                state.mario.Location.Y + Constants.SMALL_MARIO_HEIGHT - Constants.FIRE_MARIO_HEIGHT);
        }
        public override MarioStateEnum State => MarioStateEnum.Small;
    }
}
