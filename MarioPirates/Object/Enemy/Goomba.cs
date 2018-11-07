using Microsoft.Xna.Framework;
using System;

namespace MarioPirates
{
    internal class Goomba : GameObjectRigidBody, IDisposable
    {
        public Goomba(int x, int y) : base(x, y, Constants.GOOMBA_WIDTH * 2, Constants.GOOMBA_HEIGHT * 2)
        {
            Sprite = SpriteFactory.Ins.CreateSprite("goomba");
            RigidBody.Mass = Constants.GOOMBA_MASS;
            RigidBody.CollisionLayerMask = CollisionLayer.Enemy;
            RigidBody.Velocity = Constants.GOOMBA_INITIAL_VELOCITY;
        }

        public override void PreCollide(GameObjectRigidBody other, CollisionSide side)
        {
            if (other is Koopa koopa && koopa.Stomped)
            {
                RigidBody.Mass = Constants.OBJECT_PRECOLLISION_MASS;
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
                Score.Ins.Value += 100;
                EventManager.Ins.RaiseEvent(EventEnum.GameObjectDestroy, this, new GameObjectDestroyEventArgs(this), Constants.ENEMY_COLLISION_EVENT_DT);
            }
            else if (other is Koopa koopa && koopa.Stomped)
            {
                // TODO: flip
                RigidBody.CollisionLayerMask = CollisionLayer.None;
                RigidBody.Velocity = Constants.GOOMBA_STOMPED_KOOPA_COLLISION_VELOCITY;
                EventManager.Ins.RaiseEvent(EventEnum.GameObjectDestroy, this, new GameObjectDestroyEventArgs(this), Constants.ENEMY_COLLISION_EVENT_DT);
            }
        }

        public void Dispose()
        {
            Score.Ins.Value += Constants.GOOMBA_POINTS;
        }
    }
}
