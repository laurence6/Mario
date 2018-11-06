using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal class GreenMushroom : GameObjectRigidBody
    {
        public GreenMushroom(int dstX, int dstY) : base(dstX, dstY, Constants.MUSHROOM_WIDTH * 2, Constants.MUSHROOM_HEIGHT * 2)
        {
            Sprite = SpriteFactory.Ins.CreateSprite("greenmushroom");
            RigidBody.Mass = Constants.MUSHROOM_MASS;
            RigidBody.CollisionLayerMask = CollisionLayer.Mushroom;
            RigidBody.Velocity = Constants.MUSHROOM_INITIAL_VELOCITY;
        }

        public override void PreCollide(GameObjectRigidBody other, CollisionSide side)
        {
            if (other is Mario)
            {
                RigidBody.Mass = Constants.OBJECT_PRECOLLISION_MASS;
                EventManager.Ins.RaiseEvent(EventEnum.GameObjectDestroy, this, new GameObjectDestroyEventArgs(this));
            }
            base.PostCollide(other, side);
        }
    }
}
