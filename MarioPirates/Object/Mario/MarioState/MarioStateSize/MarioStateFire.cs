using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal class MarioStateFire : MarioStateSize
    {
        public MarioStateFire(MarioState state) : base(state)
        {
            state.mario.Size = new Point(Constants.FIRE_MARIO_WIDTH, Constants.FIRE_MARIO_HEIGHT);
        }

        public override void Fire()
        {
        }

        public override void Small()
        {
            base.Small();
            state.mario.Location =
                new Vector2(
                state.mario.Location.X - (Constants.FIRE_MARIO_WIDTH - Constants.SMALL_MARIO_WIDTH) / 2,
                state.mario.Location.Y + Constants.FIRE_MARIO_HEIGHT - Constants.SMALL_MARIO_HEIGHT);
        }

        public override void Dead()
        {
            base.Dead();
            state.mario.Location =
                new Vector2(
                state.mario.Location.X - (Constants.FIRE_MARIO_WIDTH - Constants.DEAD_MARIO_WIDTH) / 2,
                state.mario.Location.Y + Constants.FIRE_MARIO_HEIGHT - Constants.DEAD_MARIO_HEIGHT);
        }

        public override MarioStateEnum State => MarioStateEnum.Fire;
    }
}
