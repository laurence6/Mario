using System;

namespace MarioPirates
{
    internal class Fish : GameObjectRigidBody, IDisposable
    {
        public Fish(int x, int y) : base(x, y, Constants.FISH_WIDTH * 2, Constants.FISH_HEIGHT * 2)
        {
            Sprite = SpriteFactory.Ins.CreateSprite(Constants.FISH_SPRITE);
            RigidBody.Mass = Constants.FISH_MASS;
            RigidBody.CollisionLayerMask = CollisionLayer.Enemy;
            RigidBody.Velocity = Constants.FISH_INITIAL_VELOCITY;
        }

        public void Dispose()
        {
            Score.Ins.Value += Constants.FISH_POINTS;
        }
    }
}
