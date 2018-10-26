using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal class Star : GameObjectRigidBody
    {
        private const int starWidth = 14, starHeight = 16;

        public Star(int dstX, int dstY) : base(dstX, dstY, starWidth * 2, starHeight * 2)
        {
            Sprite = SpriteFactory.Ins.CreateSprite("star");
            RigidBody.Mass = 0.05f;

            RigidBody.Velocity = new Vector2(100f, 0f);
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
                RigidBody.Velocity = new Vector2(RigidBody.Velocity.X, -200f);
            }
            base.PostCollide(other, side);
        }
    }
}
