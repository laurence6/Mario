using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal interface IRigidBody
    {
        // Collision
        Rectangle Bound { get; }
        byte CollideMask { get; set; }

        // Object property
        float Mass { get; set; }

        Vector2 Force { get; }
        Vector2 Accel { get; }
        Vector2 Velocity { get; }

        void ApplyForce(WorldForce force);
        void ApplyForce(Vector2 force);

        void Update(float dt);

        void OnColide(IRigidBody other);
    }
}
