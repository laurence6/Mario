using System;

namespace MarioPirates
{
    internal class Goomba : GameObjectRigidBody, IDisposable
    {
        public Goomba(int x, int y) : base(x, y, Constants.GOOMBA_WIDTH * 2, Constants.GOOMBA_HEIGHT * 2)
        {
            Sprite = SpriteFactory.Ins.CreateSprite(Constants.GOOMBA_SPRITE);
            RigidBody.Mass = Constants.GOOMBA_MASS;
            RigidBody.CollisionLayerMask = CollisionLayer.Enemy;
            RigidBody.Velocity = Constants.GOOMBA_INITIAL_VELOCITY;
        }

        public void Dispose()
        {
            Score.Ins.Value += Constants.GOOMBA_POINTS;
        }
    }
}
