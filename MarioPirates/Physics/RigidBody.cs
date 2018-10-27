using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace MarioPirates
{
    internal class RigidBody
    {
        public readonly GameObjectRigidBody Object;

        public Rectangle Bound => new Rectangle((int)Object.Location.X, (int)Object.Location.Y, Object.Size.X, Object.Size.Y);

        public CollisionLayer CollisionLayerMask { get; set; } = CollisionLayer.All;
        public CollisionSide CollisionSideMask { get; set; } = CollisionSide.All;

        private MotionEnum motion = MotionEnum.Static;
        public MotionEnum Motion
        {
            get => motion;
            set
            {
                motion = value;
                if (motion == MotionEnum.Static)
                    Velocity = Vector2.Zero;
            }
        }

        public float Mass { get; set; } = 1e24f;
        public float InvMass => Motion == MotionEnum.Dynamic ? 1f / Mass : 0f;

        public float CoR { get; set; } = 1f;

        public Vector2 Force { get; private set; }
        private Vector2 velocity;
        public Vector2 Velocity
        {
            get => velocity;
            set => velocity = value.DeEPS().Clamp(-480f, 480f);
        }
        private Vector2 Accel => Force * InvMass;

        public bool Grounded { get; set; } = false;

        private WorldForce worldForce = WorldForce.Gravity;

        public RigidBody(GameObjectRigidBody gameObject)
        {
            Object = gameObject;
        }

        public void ApplyForce(WorldForce force)
        {
            worldForce = force;
        }

        public void ApplyForce(Vector2 force)
        {
            Force += force;
        }

        public void Step(float dt)
        {
            if (Motion == MotionEnum.Static)
                return;

            var nextVelocity = Velocity + dt * Accel;

            // XXX: a hacky approx to simulate friction
            if (worldForce.HasOne(WorldForce.Friction))
            {
                if (worldForce.HasOne(WorldForce.Gravity))
                    nextVelocity.X *= 0.0001f.Pow(dt);
                else
                    nextVelocity *= 0.0001f.Pow(dt);
            }

            // XXX: another hacky approx to simulate gravity
            if (worldForce.HasOne(WorldForce.Gravity))
                if (!Grounded)
                    nextVelocity.Y += 6f;

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
            if ((r1.CollisionLayerMask & r2.CollisionLayerMask) != 0)
            {
                Rectangle b1 = r1.Bound, b2 = r2.Bound;
                Rectangle.Intersect(ref b1, ref b2, out var ints);
                if (!ints.IsEmpty)
                {
                    var side = CollisionSide.All;
                    var depth = 0f;

                    var relVel = r2.Velocity - r1.Velocity;
                    if (b1.Right > b2.Right || relVel.X >= 0)
                        side &= ~CollisionSide.Right;
                    if (b1.Left < b2.Left || relVel.X <= 0)
                        side &= ~CollisionSide.Left;
                    if (b1.Top < b2.Top || relVel.Y <= 0)
                        side &= ~CollisionSide.Top;
                    if (b1.Bottom > b2.Bottom || relVel.Y >= 0)
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

                        if (r1.CollisionSideMask.HasOne(side) && r2.CollisionSideMask.HasOne(side.Invert()))
                        {
                            collisions.Add(new CollideEventArgs(o1, o2, side, depth));
                        }
                    }
                }
            }
        }

        public static (Vector2, Vector2) ResolveCollide(in CollideEventArgs ce)
        {
            RigidBody o1 = ce.object1.RigidBody, o2 = ce.object2.RigidBody;
            var normal = Vector2.Zero;
            switch (ce.side)
            {
                case CollisionSide.Top:
                    normal.Y = 1f;
                    break;
                case CollisionSide.Bottom:
                    normal.Y = -1f;
                    break;
                case CollisionSide.Left:
                    normal.X = 1f;
                    break;
                case CollisionSide.Right:
                    normal.X = -1f;
                    break;
            }
            var dp = (o2.Velocity * normal - o1.Velocity * normal)
                .DivS(o1.InvMass + o2.InvMass)
                * normal;
            return ((o1.CoR + 1f) * o1.InvMass * dp, (o2.CoR + 1f) * o2.InvMass * -dp);
        }
    }
}
