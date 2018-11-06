using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal class Star : GameObjectRigidBody
    {
        public Star(int dstX, int dstY) : base(dstX, dstY, Constants.STAR_WIDTH * 2, Constants.STAR_HEIGHT * 2)
        {
            Sprite = SpriteFactory.Ins.CreateSprite("star");
            RigidBody.Mass = Constants.STAR_MASS;
            RigidBody.CollisionLayerMask = CollisionLayer.Star;
            RigidBody.Velocity = Constants.STAR_INITIAL_VELOCITY;
        }

        public override void PreCollide(GameObjectRigidBody other, CollisionSide side)
        {
            if (other is Mario)
            {
                EventManager.Ins.RaiseEvent(EventEnum.GameObjectDestroy, this, new GameObjectDestroyEventArgs(this));
            }
            base.PostCollide(other, side);
        }

        public override void PostCollide(GameObjectRigidBody other, CollisionSide side)
        {
            if (RigidBody.Grounded)
            {
                RigidBody.Velocity = new Vector2(RigidBody.Velocity.X, Constants.STAR_COLLISION_VELOCITY_Y);
            }
            base.PostCollide(other, side);
        }
    }
}
