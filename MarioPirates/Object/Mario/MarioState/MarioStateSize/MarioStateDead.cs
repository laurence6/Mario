using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal class MarioStateDead : MarioStateSize
    {
        public MarioStateDead(MarioState state) : base(state)
        {
            state.mario.Size = new Point(Constants.DEAD_MARIO_WIDTH, Constants.DEAD_MARIO_HEIGHT);
            state.mario.RigidBody.CollisionLayerMask = CollisionLayer.None;
        }

        public override void Dead()
        {
        }

        public override bool IsDead => true;

        public override MarioStateEnum State => MarioStateEnum.Dead;
    }
}
