using Microsoft.Xna.Framework;

namespace MarioPirates
{
    using Event;
    internal class Goomba : GameObjectRigidBody
    {
        private const int goombaWidth = 16, goombaHeight = 16;

        public Goomba(int x, int y) : base(x, y, goombaWidth * 2, goombaHeight * 2)
        {
            Sprite = SpriteFactory.CreateSprite("goomba");
            RigidBody.Mass = 0.1f;
        }

        public override void OnCollide(GameObjectRigidBody other, CollisionSide side)
        {
            if (other is Mario mario)
            {
                if (side == CollisionSide.Top || mario.State.IsInvincible)
                {
                    Sprite = SpriteFactory.CreateSprite("goomba_stomped");
                    RigidBody.Velocity = new Vector2(0f, 0f);
                    RigidBody.CollisionLayerMask = CollisionLayer.None;
                    // TODO: disappear
                }
            }
            else if (other is Koopa)
            {
                // TODO: flip
                EventManager.RaiseEvent(EventEnum.GameObjectDestroy, this, new GameObjectDestroyEventArgs(this));
            }
            base.OnCollide(other, side);
        }
    }
}
