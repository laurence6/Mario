using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal class Koopa : GameObjectRigidBody
    {
        private const int koopaWidth = 16, koopaHeight = 23;

        public bool Stomped { get; private set; } = false;

        private readonly Sprite[] sprites;

        public Koopa(int x, int y) : base(x, y, koopaWidth * 2, koopaHeight * 2)
        {
            sprites = new Sprite[3] {
                SpriteFactory.Ins.CreateSprite("koopa_left"),
                SpriteFactory.Ins.CreateSprite("koopa_right"),
                SpriteFactory.Ins.CreateSprite("koopa_stomped"),
            };
            Sprite = sprites[0];

            RigidBody.Mass = 0.1f;
            RigidBody.CollisionLayerMask = CollisionLayer.Enemy;
            RigidBody.Velocity = new Vector2(-25f, 0f);
        }

        public override void Update(float dt)
        {
            Sprite = Stomped ? sprites[2] : RigidBody.Velocity.X < 0 ? sprites[0] : sprites[1];
            base.Update(dt);
        }

        public override void PostCollide(GameObjectRigidBody other, CollisionSide side)
        {
            if (other is Mario mario && (side == CollisionSide.Top || mario.State.IsInvincible))
            {
                if (Stomped)
                    RigidBody.Velocity = RigidBody.Velocity.X.DeEPS() != 0f ? Vector2.Zero : other.RigidBody.Bound.Center.X > RigidBody.Bound.Center.X ? new Vector2(-250f, 0f) : new Vector2(250f, 0f);
                Stomped = true;
            }
            else if (other is Fireball)
            {
                Stomped = true;
                RigidBody.CollisionLayerMask = CollisionLayer.None;
                RigidBody.Velocity = new Vector2(RigidBody.Velocity.X + (side == CollisionSide.Left ? 20f : 0f) + (side == CollisionSide.Right ? -20f : 0f), -250f);
                EventManager.Ins.RaiseEvent(EventEnum.GameObjectDestroy, this, new GameObjectDestroyEventArgs(this), 3000f);
            }
            base.PostCollide(other, side);
        }
    }
}
