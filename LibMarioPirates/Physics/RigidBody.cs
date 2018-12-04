using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace MarioPirates
{
    internal class RigidBody
    {
        public readonly GameObjectRigidBody Object;

        public Rectangle Bound { get; private set; }

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

        public float Mass { get; set; } = Constants.RIGID_BODY_MASS;
        public float InvMass => Motion == MotionEnum.Dynamic ? 1f / Mass : 0f;

        public float CoR { get; set; } = Constants.RIGID_BODY_COR;

        public Vector2 Force { get; private set; }
        private Vector2 velocity;
        public Vector2 Velocity
        {
            get => velocity;
            set => velocity = value.DeEPS().Clamp(-Constants.RIGID_BODY_VELOCITY_MAGNITUDE_BOUND, Constants.RIGID_BODY_VELOCITY_MAGNITUDE_BOUND);
        }
        public Vector2 Accel => Force * InvMass;

        public bool Grounded { get; set; } = false;

        public WorldForce WorldForce { get; set; } = WorldForce.Gravity;

        public RigidBody(GameObjectRigidBody gameObject)
        {
            Object = gameObject;
            UpdateBound();
        }

        public void UpdateBound()
        {
            Bound = new Rectangle((int)Object.Location.X, (int)Object.Location.Y, Object.Size.X, Object.Size.Y);
        }

        public void ApplyForce(WorldForce force)
        {
            WorldForce = force;
        }

        public void ApplyForce(Vector2 force)
        {
            Force += force;
        }

        public void Update()
        {
            Force = Vector2.Zero;
        }

        public static void DetectCollide(GameObjectRigidBody object1, GameObjectRigidBody object2, List<CollideEventArgs> collisions)
        {
            RigidBody rigidbody1 = object1.RigidBody, rigidbody2 = object2.RigidBody;
            if (rigidbody1.CollisionLayerMask.HasOne(rigidbody2.CollisionLayerMask))
            {
                Rectangle bound1 = rigidbody1.Bound, bound2 = rigidbody2.Bound;
                Rectangle.Intersect(ref bound1, ref bound2, out var ints);
                if (!ints.IsEmpty)
                {
                    var side = CollisionSide.All;
                    var depth = 0f;

                    var relVel = rigidbody2.Velocity - rigidbody1.Velocity;
                    if (bound1.Right > bound2.Right || relVel.X >= 0)
                        side &= ~CollisionSide.Right;
                    if (bound1.Left < bound2.Left || relVel.X <= 0)
                        side &= ~CollisionSide.Left;
                    if (bound1.Top < bound2.Top || relVel.Y <= 0)
                        side &= ~CollisionSide.Top;
                    if (bound1.Bottom > bound2.Bottom || relVel.Y >= 0)
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

                        if (rigidbody1.CollisionSideMask.HasOne(side) && rigidbody2.CollisionSideMask.HasOne(side.Invert()))
                        {
                            collisions.Add(new CollideEventArgs(object1, object2, side, depth));
                        }
                    }
                }
            }
        }

        public static (Vector2, Vector2) ResolveCollide(in CollideEventArgs collision)
        {
            RigidBody object1 = collision.object1.RigidBody, object2 = collision.object2.RigidBody;
            var normal = Vector2.Zero;
            switch (collision.side)
            {
                case CollisionSide.Top:
                    normal.Y = Constants.RIGID_BODY_RESOLVE_COLLIDE_NORMAL;
                    break;
                case CollisionSide.Bottom:
                    normal.Y = -Constants.RIGID_BODY_RESOLVE_COLLIDE_NORMAL;
                    break;
                case CollisionSide.Left:
                    normal.X = Constants.RIGID_BODY_RESOLVE_COLLIDE_NORMAL;
                    break;
                case CollisionSide.Right:
                    normal.X = -Constants.RIGID_BODY_RESOLVE_COLLIDE_NORMAL;
                    break;
            }
            var dp = (object2.Velocity * normal - object1.Velocity * normal)
                .DivS(object1.InvMass + object2.InvMass)
                * normal;
            return ((object1.CoR + 1f) * object1.InvMass * dp, (object2.CoR + 1f) * object2.InvMass * -dp);
        }
    }
}
