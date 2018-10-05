using Microsoft.Xna.Framework;

namespace MarioPirates
{
    using static Common;

    internal class RigidBody
    {
        public GameObject Object { get; }
        public Rectangle Bound => new Rectangle((int)Object.Location.X, (int)Object.Location.Y, Object.Size.X, Object.Size.Y);

        public byte CollideLayerMask { get; set; } = 0b1;
        public CollisionSide CollideSideMask { get; set; } = CollisionSide.All;

        public float Mass { get; set; } = 1e24f;
        private float InvMass => Object.IsStatic ? 0 : 1f / Mass;

        public float CoR { get; } = 0.5f;

        public Vector2 Force { get; private set; }
        public Vector2 Velocity { get; set; }
        private Vector2 Accel => Force * InvMass;

        private WorldForce worldForce;

        public RigidBody(GameObject gameObject)
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
