using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal class Goomba : GameObjectRigidBody
    {
        private const int goombaWidth = 16, goombaHeight = 16;

        public Goomba(int x, int y) : base(x, y, goombaWidth * 2, goombaHeight * 2)
        {
            Sprite = SpriteFactory.Ins.CreateSprite("goomba");
            RigidBody.Mass = 0.1f;

            RigidBody.Velocity = new Vector2(-25f, 0f);
        }

        public override void PreCollide(GameObjectRigidBody other, CollisionSide side)
        {
            if (other is Koopa koopa && koopa.Stomped)
            {
                RigidBody.Mass = 1e-6f;
            }
            base.PreCollide(other, side);
        }

        public override void PostCollide(GameObjectRigidBody other, CollisionSide side)
        {
            if ((other is Mario mario && (side == CollisionSide.Top || mario.State.IsInvincible)) || other is Fireball)
            {
                Sprite = SpriteFactory.Ins.CreateSprite("goomba_stomped");
                RigidBody.CollisionLayerMask = CollisionLayer.None;
                RigidBody.Velocity = Vector2.Zero;
                EventManager.Ins.RaiseEvent(EventEnum.GameObjectDestroy, this, new GameObjectDestroyEventArgs(this), 3000f);
            }
            else if (other is Koopa koopa && koopa.Stomped)
            {
                // TODO: flip
                RigidBody.CollisionLayerMask = CollisionLayer.None;
                RigidBody.Velocity = new Vector2(0f, -250f);
                EventManager.Ins.RaiseEvent(EventEnum.GameObjectDestroy, this, new GameObjectDestroyEventArgs(this), 3000f);
            }
            base.PostCollide(other, side);
        }
    }
}
