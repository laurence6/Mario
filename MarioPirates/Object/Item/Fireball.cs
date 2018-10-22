using System;
namespace MarioPirates
{
    internal class Fireball : GameObjectRigidBody
    {
        private const int fireballwidth = 10, fireballheight=10;
        public Fireball()
        {
            RigidBody.Mass = .05f;
            RigidBody.Motion = MotionEnum.Dynamic;
            Sprite = SpriteFactory.Ins.CreateSprite("fireball");
        }
        public override void Postcollide(GameObjectRigidBody other, CollisionSide side)
        {
            if (other.RigidBody.Motion == MotionEnum.Static) {
                if (side == CollisionSide.Top)
                {
                    RigidBody.Velocity = new Vector2(RigidBody.Velocity.X, 25);
                }             
            }
        }
    }

}
