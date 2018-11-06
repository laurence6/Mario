using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal class GreenMushroom : GameObjectRigidBody
    {
        public GreenMushroom(int dstX, int dstY) : base(dstX, dstY, Constants.MUSHROOM_WIDTH * 2, Constants.MUSHROOM_HEIGHT * 2) // 16, 16
        {
            Sprite = SpriteFactory.Ins.CreateSprite("greenmushroom");
            RigidBody.Mass = Constants.MUSHROOM_MASS; //0.05f
            RigidBody.CollisionLayerMask = CollisionLayer.Mushroom;
            RigidBody.Velocity = new Vector2(Constants.MUSHROOM_INITIAL_VELOCITY, 0f); // 50
        }

        public override void PreCollide(GameObjectRigidBody other, CollisionSide side)
        {
            if (other is Mario)
            {
                RigidBody.Mass = Constants.MUSHROOM_PRECOLLISION_MASS; //1e-6f
                EventManager.Ins.RaiseEvent(EventEnum.GameObjectDestroy, this, new GameObjectDestroyEventArgs(this));
            }
            base.PostCollide(other, side);
        }
    }
}
