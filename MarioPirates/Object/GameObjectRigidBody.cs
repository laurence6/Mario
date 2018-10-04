namespace MarioPirates
{
    internal abstract class GameObjectRigidBody : GameObject
    {
        protected GameObjectRigidBody()
        {
            RigidBody = new DefaultRigidBody(this);
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
