using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal class Fireball : GameObjectRigidBody
    {
        public Fireball(int dstX, int dstY) : base(dstX, dstY, Constants.FIREBALL_WIDTH * 2, Constants.FIREBALL_HEIGHT * 2)
        {
            Sprite = SpriteFactory.Ins.CreateSprite("fireball");
            RigidBody.Mass = Constants.FIREBALL_MASS;
            RigidBody.CollisionLayerMask = CollisionLayer.Enemy | CollisionLayer.Static;
            RigidBody.Motion = MotionEnum.Dynamic;
        }

        public override void PreCollide(GameObjectRigidBody other, CollisionSide side)
        {
            RigidBody.Mass = Constants.OBJECT_PRECOLLISION_MASS;
            base.PreCollide(other, side);
        }

        public override void PostCollide(GameObjectRigidBody other, CollisionSide side)
        {
            base.PostCollide(other, side);
            if (RigidBody.Grounded)
            {
                RigidBody.Velocity = new Vector2(RigidBody.Velocity.X, Constants.FIREBALL_COLLISION_VELOCITY.Y);
            }
            if (other is Goomba || other is Koopa)
            {
                EventManager.Ins.RaiseEvent(EventEnum.GameObjectDestroy, this, new GameObjectDestroyEventArgs(this));
            }
        }
    }
}
