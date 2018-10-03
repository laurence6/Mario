using Microsoft.Xna.Framework;

namespace MarioPirates
{
    using static Common;

    internal abstract class BaseRigidBody
    {
        public virtual Rectangle Bound { get; }
        public byte CollideMask { get; } = 0b1;

        public float Mass { get; set; } = 1e9f;
        public float CoR { get; } = 0.5f;

        public Vector2 Force { get; protected set; }
        public Vector2 Accel => Force / Mass;
        public Vector2 Velocity { get; set; }

        public GameObject Object { get; protected set; }

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

        public void Step(float dt)
        {
            var nextVelocity = Velocity + dt * Accel;

            // XXX: a hacky approx to simulate friction
            if ((worldForce & WorldForce.Friction) != 0)
                nextVelocity *= Pow(0.0001f, dt); // TODO: .X

            Object.Location += dt * (nextVelocity + Velocity) / 2;
            Velocity = nextVelocity;
        }

        public void Update()
        {
            Force = Vector2.Zero;
        }
    }
}
