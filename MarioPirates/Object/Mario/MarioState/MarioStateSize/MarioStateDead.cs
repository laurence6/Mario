using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal class MarioStateDead : MarioStateSize
    {
        public const int marioWidth = 30, marioHeight = 28;

        public MarioStateDead(MarioState state) : base(state)
        {
            state.mario.Size = new Point(marioWidth, marioHeight);
            state.mario.RigidBody.CollisionLayerMask = CollisionLayer.None;
        }

        public override void Dead()
        {
        }

        public override bool IsDead => true;

        public override MarioStateEnum State => MarioStateEnum.Dead;
    }
}
