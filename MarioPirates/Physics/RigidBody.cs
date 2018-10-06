using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace MarioPirates
{
    using Event;
    using static Common;

    internal class RigidBody
    {
        public readonly GameObject Object;

        public Rectangle Bound => new Rectangle((int)Object.Location.X, (int)Object.Location.Y, Object.Size.X, Object.Size.Y);

        public byte CollideLayerMask { get; set; } = 0b1;
        public CollisionSide CollideSideMask { get; set; } = CollisionSide.All;

        public float Mass { get; set; } = 1e24f;
        public float InvMass => Object.IsStatic ? 0 : 1f / Mass;

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

        public static void DetectCollide(GameObject o1, GameObject o2, List<CollideEvent> collisions)
        {
            RigidBody r1 = o1.RigidBody, r2 = o2.RigidBody;
            if (r1 != null && r2 != null)
            {
                if ((r1.CollideLayerMask & r2.CollideLayerMask) != 0)
                {
                    Rectangle b1 = r1.Bound, b2 = r2.Bound;
                    Rectangle.Intersect(ref b1, ref b2, out var ints);
                    if (!ints.IsEmpty)
                    {
                        var side = CollisionSide.All;
                        var depth = 0f;
                        {
                            Point c1 = b1.Center, c2 = b2.Center;
                            var relVel = r2.Velocity - r1.Velocity;
                            if (c1.X > c2.X || relVel.X >= 0)
                                side &= ~CollisionSide.Right;
                            if (c1.X < c2.X || relVel.X <= 0)
                                side &= ~CollisionSide.Left;
                            if (c1.Y < c2.Y || relVel.Y <= 0)
                                side &= ~CollisionSide.Top;
                            if (c1.Y > c2.Y || relVel.Y >= 0)
                                side &= ~CollisionSide.Bottom;
                        }
                        if (side != CollisionSide.None)
                        {
                            if (ints.Width > ints.Height)
                            {
                                side &= CollisionSide.TopBottom;
                                depth = ints.Height.Abs();
                            }
                            else
                            {
                                side &= CollisionSide.LeftRight;
                                depth = ints.Width.Abs();
                            }

                            if ((r1.CollideSideMask & side) != 0 && (r2.CollideSideMask & side.Invert()) != 0)
                                collisions.Add(new CollideEvent(o1, o2, side, depth));
                        }
                    }
                }
            }
        }

        public static void ResolveCollide(in CollideEvent ce, out Vector2 v1, out Vector2 v2)
        {
            var normal = Vector2.Zero;
            switch (ce.Side)
            {
                case CollisionSide.Top:
                    normal.Y = ce.Depth;
                    break;
                case CollisionSide.Bottom:
                    normal.Y = -ce.Depth;
                    break;
                case CollisionSide.Left:
                    normal.X = ce.Depth;
                    break;
                case CollisionSide.Right:
                    normal.X = -ce.Depth;
                    break;
            }
            normal.Normalize();
            RigidBody o1 = ce.Object1.RigidBody, o2 = ce.Object2.RigidBody;
            var dp = (o2.Velocity * normal - o1.Velocity * normal)
                .DivS(o1.InvMass + o2.InvMass)
                * normal;
            v1 = (o1.CoR + 1f) * o1.InvMass * dp;
            v2 = (o2.CoR + 1f) * o2.InvMass * -dp;
        }
    }
}
