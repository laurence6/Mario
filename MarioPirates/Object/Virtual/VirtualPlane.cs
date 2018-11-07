using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioPirates
{
    internal class VirtualPlane : GameObjectRigidBody
    {
        public VirtualPlane(float locX, float locY) : base(locX, locY, Constants.SCREEN_WIDTH, 1)
        {
            IsLocationAbsolute = true;
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
            other.RigidBody.CollisionLayerMask = CollisionLayer.None;
            EventManager.Ins.RaiseEvent(EventEnum.GameObjectDestroy, this, new GameObjectDestroyEventArgs(other), Constants.VIRTUAL_PLANE_EVENT_DT);
        }

        public override void PostCollide(GameObjectRigidBody other, CollisionSide side)
        {
            base.PostCollide(other, side);
            other.RigidBody.Velocity = Constants.VIRTUAL_PLANE_COLLISION_VELOCITY;
        }
    }
}
