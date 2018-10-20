namespace MarioPirates
{
    internal abstract class GameObjectRigidBody : GameObject
    {
        public readonly RigidBody RigidBody;

        protected GameObjectRigidBody(float locX, float locY, int sizeX, int sizeY) : base(locX, locY, sizeX, sizeY)
        {
            RigidBody = new RigidBody(this);
        }

        public override void Update(float dt)
        {
            RigidBody.Update();
            base.Update(dt);
        }
        public virtual void Step(float dt)
        {
            RigidBody.Step(dt);
        }

        public virtual void PreCollide(GameObjectRigidBody other, CollisionSide side)
        {
        }

        public virtual void PostCollide(GameObjectRigidBody other, CollisionSide side)
        {
        }
    }
}
