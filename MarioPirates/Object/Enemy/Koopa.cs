using Microsoft.Xna.Framework;
using System;

namespace MarioPirates
{
    internal class Koopa : GameObjectRigidBody, IDisposable
    {
        public bool Stomped { get; private set; } = false;

        private readonly Sprite[] sprites;

        public Koopa(int x, int y) : base(x, y, Constants.KOOPA_WIDTH * 2, Constants.KOOPA_HEIGHT * 2) // 16, 23
        {
            sprites = new Sprite[3] {
                SpriteFactory.Ins.CreateSprite("koopa_left"),
                SpriteFactory.Ins.CreateSprite("koopa_right"),
                SpriteFactory.Ins.CreateSprite("koopa_stomped"),
            };
            Sprite = sprites[0];

            RigidBody.Mass = Constants.KOOPA_MASS; // 0.1
            RigidBody.CollisionLayerMask = CollisionLayer.Enemy;
            RigidBody.Velocity = new Vector2(Constants.KOOPA_INITIAL_VELOCITY, 0f); // -25
        }

        public override void Update(float dt)
        {
            Sprite = Stomped ? sprites[2] : RigidBody.Velocity.X < 0 ? sprites[0] : sprites[1];
            base.Update(dt);
        }

        public override void PostCollide(GameObjectRigidBody other, CollisionSide side)
        {
            base.PostCollide(other, side);
            if (other is Mario mario && (side == CollisionSide.Top || mario.State.IsInvincible))
            {
                RigidBody.Velocity = new Vector2(!Stomped || RigidBody.Velocity.X.DeEPS() != 0f ? 0f : other.RigidBody.Bound.Center.X > RigidBody.Bound.Center.X ? -Constants.KOOPA_MARIO_COLLISION_VELOCITY : Constants.KOOPA_MARIO_COLLISION_VELOCITY, 0f); //-250, 250
                if (!Stomped)
                {
                    Score.Ins.Value += Constants.KOOPA_POINTS; //100
                    Stomped = true;
                }
            }
            else if (other is Fireball)
            {
                Stomped = true;
                RigidBody.CollisionLayerMask = CollisionLayer.None;
                RigidBody.Velocity = new Vector2(RigidBody.Velocity.X + (side == CollisionSide.Left ? Constants.KOOPA_FIREBALL_SIDE_COLLISION_VELOCITY : 0f) + (side == CollisionSide.Right ? -Constants.KOOPA_FIREBALL_SIDE_COLLISION_VELOCITY : 0f), Constants.KOOPA_FIREBALL_COLLISION_Y_VELOCITY); // 20, -20, -250
                EventManager.Ins.RaiseEvent(EventEnum.GameObjectDestroy, this, new GameObjectDestroyEventArgs(this), Constants.DESTROY_KOOPA_DELAY); // 3000
            }
        }

        public void Dispose()
        {
            Score.Ins.Value += Stomped ? Constants.KOOPA_POINTS : 2 * Constants.KOOPA_POINTS; //100, 200
        }
    }
}
