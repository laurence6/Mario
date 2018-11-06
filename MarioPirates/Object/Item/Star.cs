using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal class Star : GameObjectRigidBody
    {
        public Star(int dstX, int dstY) : base(dstX, dstY, Constants.STAR_WIDTH * 2, Constants.STAR_HEIGHT * 2) // 14, 16
        {
            Sprite = SpriteFactory.Ins.CreateSprite("star");
            RigidBody.Mass = Constants.STAR_MASS; //0.05f
            RigidBody.CollisionLayerMask = CollisionLayer.Star;
            RigidBody.Velocity = new Vector2(Constants.STAR_INITIAL_VELOCITY, 0f); // 100
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
                RigidBody.Velocity = new Vector2(RigidBody.Velocity.X, Constants.STAR_COLLISION_VELOCITY); // -200f
            }
            base.PostCollide(other, side);
        }
    }
}
