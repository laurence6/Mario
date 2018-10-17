using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal abstract class GameObjectRigidBody : GameObject
    {
        public readonly RigidBody RigidBody;

        public override Vector2 Location { get => location; set => location = value; }
        public override Point Size { get => size; set => size = value; }

        protected GameObjectRigidBody(float locX, float locY, int sizeX, int sizeY) : base(locX, locY, sizeX, sizeY)
        {
            RigidBody = new RigidBody(this);
        }

        public override void Step(float dt)
        {
            RigidBody.Step(dt);
        }

        public override void Update(float dt)
        {
            RigidBody.Update();
            base.Update(dt);
        }

        public virtual void OnCollide(GameObjectRigidBody other, CollisionSide side)
        {
        }
    }
}
