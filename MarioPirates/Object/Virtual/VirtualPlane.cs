using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioPirates
{
    internal class VirtualPlane : GameObjectRigidBody
    {
        public VirtualPlane(float locX, float locY) : base(locX, locY, Camera.ScreenWidth, 1)
        {
        }

        public override void Update(float dt)
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
        }

        public override void PreCollide(GameObjectRigidBody other, CollisionSide side)
        {
            base.PostCollide(other, side);
            if (other is Mario mario)
            {
                mario.State.Dead();
            }
            else
            {
                other.RigidBody.CollisionLayerMask = CollisionLayer.None;
                EventManager.Ins.RaiseEvent(EventEnum.GameObjectDestroy, this, new GameObjectDestroyEventArgs(other), 1000f);
            }
        }

        public override void PostCollide(GameObjectRigidBody other, CollisionSide side)
        {
            base.PostCollide(other, side);
            other.RigidBody.Velocity = new Vector2(0f, 100f);
        }
    }
}
