using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal abstract class GameObjectRigidBody : GameObjectBase
    {
        private Vector2 location;
        public override Vector2 Location
        {
            get => IsLocationAbsolute ? new Vector2(location.X + Camera.Ins.Offset, location.Y) : location;
            set { location = value; location.X -= IsLocationAbsolute ? Camera.Ins.Offset : 0f; RigidBody?.UpdateBound(); }
        }

        private Point size;
        public override Point Size { get => size; set { size = value; RigidBody?.UpdateBound(); } }

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
    }
}
