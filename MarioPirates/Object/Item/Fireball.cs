using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal class Fireball : GameObjectRigidBody
    {
        private const int fireballwidth = 10, fireballheight = 10;

        public Fireball(int dstX, int dstY) : base(dstX, dstY, fireballwidth * 2, fireballheight * 2)
        {
            RigidBody.Mass = .05f;
            RigidBody.Motion = MotionEnum.Dynamic;
            Sprite = SpriteFactory.Ins.CreateSprite("fireball");
        }

        public override void PreCollide(GameObjectRigidBody other, CollisionSide side)
        {
            RigidBody.Mass = 1e-6f;
            base.PreCollide(other, side);
        }

        public override void PostCollide(GameObjectRigidBody other, CollisionSide side)
        {
            if (RigidBody.Grounded)
            {
                RigidBody.Velocity = new Vector2(RigidBody.Velocity.X, -200f);
            }
            if (other is Goomba || other is Koopa)
            {
                EventManager.Ins.RaiseEvent(EventEnum.GameObjectDestroy, this, new GameObjectDestroyEventArgs(this));
            }
            base.PostCollide(other, side);
        }
    }
}
