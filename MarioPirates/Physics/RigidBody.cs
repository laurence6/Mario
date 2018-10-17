using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace MarioPirates
{
    using Event;
    using static Common;

    internal class RigidBody
    {
        public readonly GameObjectRigidBody Object;

        public Rectangle Bound => new Rectangle((int)Object.Location.X, (int)Object.Location.Y, Object.Size.X, Object.Size.Y);

        public CollisionLayer CollideLayerMask { get; set; } = CollisionLayer.Normal;
        public CollisionSide CollideSideMask { get; set; } = CollisionSide.All;

        public float Mass { get; set; } = 1e24f;
        public float InvMass => Object.IsStatic ? 0 : 1f / Mass;

        public float CoR { get; } = 0.5f;

        public Vector2 Force { get; private set; }
        private Vector2 velocity;
        public Vector2 Velocity
        {
            get => velocity;
            set => velocity = value.DeEPS();
        }
        private Vector2 Accel => Force * InvMass;

        private WorldForce worldForce;

        public RigidBody(GameObjectRigidBody gameObject)
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

        public static void DetectCollide(GameObjectRigidBody o1, GameObjectRigidBody o2, List<CollideEventArgs> collisions)
        {
            RigidBody r1 = o1.RigidBody, r2 = o2.RigidBody;
            if ((r1.CollideLayerMask & r2.CollideLayerMask) != 0)
            {
                Rectangle b1 = r1.Bound, b2 = r2.Bound;
                Rectangle.Intersect(ref b1, ref b2, out var ints);
                if (!ints.IsEmpty)
                {
                    var side = CollisionSide.All;
                    var depth = 0f;

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
                            collisions.Add(new CollideEventArgs(o1, o2, side, depth));
                    }
                }
            }
        }

        public static ValueTuple<Vector2, Vector2> ResolveCollide(in CollideEventArgs ce)
        {
            var normal = Vector2.Zero;
            switch (ce.side)
            {
                case CollisionSide.Top:
                    normal.Y = ce.depth;
                    break;
                case CollisionSide.Bottom:
                    normal.Y = -ce.depth;
                    break;
                case CollisionSide.Left:
                    normal.X = ce.depth;
                    break;
                case CollisionSide.Right:
                    normal.X = -ce.depth;
                    break;
            }
            normal.Normalize();
            RigidBody o1 = ce.object1.RigidBody, o2 = ce.object2.RigidBody;
            var dp = (o2.Velocity * normal - o1.Velocity * normal)
                .DivS(o1.InvMass + o2.InvMass)
                * normal;
            return ((o1.CoR + 1f) * o1.InvMass * dp, (o2.CoR + 1f) * o2.InvMass * -dp);
        }
    }
}
