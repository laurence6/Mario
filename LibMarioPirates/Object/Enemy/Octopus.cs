using System;

namespace MarioPirates
{
    internal class Octopus : GameObjectRigidBody, IDisposable
    {
        public Octopus(int x, int y) : base(x, y, Constants.OCTOPUS_WIDTH * 2, Constants.OCTOPUS_HEIGHT * 2)
        {
            Sprite = SpriteFactory.Ins.CreateSprite(Constants.OCTOPUS_SPRITE);
            RigidBody.Mass = Constants.OCTOPUS_MASS;
            RigidBody.CollisionLayerMask = CollisionLayer.Enemy;
            RigidBody.Velocity = Constants.OCTOPUS_INITIAL_VELOCITY;
        }

        public void Dispose()
        {
            Score.Ins.Value += Constants.OCTOPUS_POINTS;
        }
    }
}
