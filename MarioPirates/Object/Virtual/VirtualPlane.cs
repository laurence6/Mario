using Microsoft.Xna.Framework.Graphics;

namespace MarioPirates
{
    internal class VirtualPlane : GameObjectRigidBody
    {
        public VirtualPlane(float locX, float locY) : base(locX, locY, Constants.SCREEN_WIDTH, 32)
        {
            IsLocationAbsolute = true;
        }

        public override void Update(float dt)
        {
            RigidBody.UpdateBound();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
        }

        public override void PreCollide(GameObjectRigidBody other, CollisionSide side)
        {
            base.PostCollide(other, side);
            other.RigidBody.CollisionLayerMask = CollisionLayer.None;
            EventManager.Ins.RaiseEvent(EventEnum.GameObjectDestroy, this, new GameObjectDestroyEventArgs(other));
        }
    }
}
