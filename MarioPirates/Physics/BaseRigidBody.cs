using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal abstract class BaseRigidBody : IRigidBody
    {
        public virtual Rectangle Bound { get; }
        public byte CollideMask { get; set; } = 0b1;

        public float Mass { get; set; } = 1e9f;

        public Vector2 Force { get; protected set; }
        public Vector2 Accel => Force / Mass;
        public Vector2 Velocity { get; protected set; }

        protected GameObject Object;

        protected WorldForce worldForce;

        public BaseRigidBody(GameObject gameObject)
        {
            Object = gameObject;
        }

        public void ApplyForce(WorldForce force)
        {
            worldForce |= force;
        }

        public void ApplyForce(Vector2 force)
        {
            Force += force;
        }

        public void Update(float dt)
        {
            var nextVelocity = Velocity + dt * Accel;
            if ((worldForce & WorldForce.Friction) != 0)
                nextVelocity *= 0.93f; // TODO: .X
            Object.Location += dt * (nextVelocity + Velocity) / 2;
            Velocity = nextVelocity;

            Force = Vector2.Zero;
        }

        public void OnCollide(IRigidBody other)
        {
            // TODO: handle physics simulation
        }
    }
}
