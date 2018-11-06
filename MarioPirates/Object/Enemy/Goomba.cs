using Microsoft.Xna.Framework;
using System;

namespace MarioPirates
{
    internal class Goomba : GameObjectRigidBody, IDisposable
    {
        public Goomba(int x, int y) : base(x, y, Constants.GOOMBA_WIDTH * 2, Constants.GOOMBA_HEIGHT * 2) //16, 16
        {
            Sprite = SpriteFactory.Ins.CreateSprite("goomba");
            RigidBody.Mass = Constants.GOOMBA_MASS; // 0.1
            RigidBody.CollisionLayerMask = CollisionLayer.Enemy;
            RigidBody.Velocity = new Vector2(Constants.GOOMBA_INITIAL_VELOCITY, 0f); // -25
        }

        public override void PreCollide(GameObjectRigidBody other, CollisionSide side)
        {
            if (other is Koopa koopa && koopa.Stomped)
            {
                RigidBody.Mass = Constants.GOOMBA_PRECOLLISION_MASS; //1e-6f
            }
            base.PreCollide(other, side);
        }

        public override void PostCollide(GameObjectRigidBody other, CollisionSide side)
        {
            base.PostCollide(other, side);
            if ((other is Mario mario && (side == CollisionSide.Top || mario.State.IsInvincible)) || other is Fireball)
            {
                Sprite = SpriteFactory.Ins.CreateSprite("goomba_stomped");
                RigidBody.CollisionLayerMask = CollisionLayer.None;
                RigidBody.Velocity = Vector2.Zero;
                EventManager.Ins.RaiseEvent(EventEnum.GameObjectDestroy, this, new GameObjectDestroyEventArgs(this), Constants.DESTROY_GOOMBA_DELAY); //3000
            }
            else if (other is Koopa koopa && koopa.Stomped)
            {
                // TODO: flip
                RigidBody.CollisionLayerMask = CollisionLayer.None;
                RigidBody.Velocity = new Vector2(0f, -Constants.GOOMBA_STOMPED_KOOPA_COLLISION_VELOCITY); // -250
                EventManager.Ins.RaiseEvent(EventEnum.GameObjectDestroy, this, new GameObjectDestroyEventArgs(this), Constants.DESTROY_GOOMBA_DELAY); // 3000
            }
        }

        public void Dispose()
        {
            Score.Ins.Value += Constants.GOOMBA_POINTS; // 100
        }
    }
}
