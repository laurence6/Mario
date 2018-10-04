namespace MarioPirates
{
    internal abstract class GameObjectRigidBody : GameObject
    {
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
    }
}
