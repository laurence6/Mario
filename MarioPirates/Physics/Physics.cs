using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace MarioPirates
{
    internal static class Physics
    {
        private static List<CollideEventArgs> collisions = new List<CollideEventArgs>();

        private static HashSet<GameObjectRigidBody> objectsChecked = new HashSet<GameObjectRigidBody>();
        private static HashSet<GameObjectRigidBody> objectsNearby = new HashSet<GameObjectRigidBody>();
        private static HashSet<GameObjectRigidBody> potentialSupport = new HashSet<GameObjectRigidBody>();

        private static Dictionary<RigidBody, Vector3> locationFix = new Dictionary<RigidBody, Vector3>();
        private static Dictionary<RigidBody, Vector3> velocityFix = new Dictionary<RigidBody, Vector3>();

        public static void Reset()
        {
            collisions.Clear();
            objectsChecked.Clear();
            objectsNearby.Clear();
            potentialSupport.Clear();
            velocityFix.Clear();
            locationFix.Clear();
        }

        public static void Simulate(float dt, HashMap container)
        {
            var ddt = dt / Constants.N_STEPS;

            for (var s = 0; s < Constants.N_STEPS; s++)
            {
                SimulateGrounded(container);

                container.ForEachVisible(o => o.Step(ddt));

                SimulateCollision(container);
            }
        }

        private static void SimulateGrounded(HashMap container)
        {
            container.Rebuild();
            container.ForEachVisible(object1 =>
            {
                if (object1.RigidBody.Motion != MotionEnum.Dynamic)
                    return;

                object1.RigidBody.Grounded = false;

                if (object1.RigidBody.Velocity.Y < 0f)
                    return;

                var bound = object1.RigidBody.Bound;
                var potentialSupportUpper = new Rectangle(bound.Left, bound.Bottom + 1, bound.Width, 1);
                container.Find(potentialSupportUpper, potentialSupport);
                foreach (var object2 in potentialSupport)
                {
                    if (object1.RigidBody.CollisionLayerMask.HasOne(object2.RigidBody.CollisionLayerMask)
                        && object1.RigidBody.CollisionSideMask.HasOne(CollisionSide.Bottom) && object2.RigidBody.CollisionSideMask.HasOne(CollisionSide.Top)
                        && object2.RigidBody.Bound.Intersects(potentialSupportUpper))
                    {
                        object1.RigidBody.Grounded = true;
                        collisions.Add(new CollideEventArgs(object1, object2, CollisionSide.Bottom, 0f));
                    }
                }
                potentialSupport.Clear();
            });
            collisions.ForEach(collision =>
            {
                CollisionHandler.PreCollide(collision.object1, collision.object2);
                CollisionHandler.PreCollide(collision.object2, collision.object1);
            });
            collisions.ForEach(collision =>
            {
                collision.object1.RigidBody.Velocity = new Vector2(collision.object1.RigidBody.Velocity.X, 0f);
            });
            collisions.Consume(collision =>
            {
                CollisionHandler.PostCollide(collision.object1, collision.object2, collision.side);
                CollisionHandler.PostCollide(collision.object2, collision.object1, collision.side.Invert());
            });
        }

        private static void SimulateCollision(HashMap container)
        {
            container.Rebuild();
            container.ForEachVisible(object1 =>
            {
                if (object1.RigidBody.Motion != MotionEnum.Dynamic)
                    return;

                container.Find(object1.RigidBody.Bound, objectsNearby);
                objectsNearby.Consume(object2 =>
                {
                    if (object1 != object2 && !objectsChecked.Contains(object2))
                        RigidBody.DetectCollide(object1, object2, collisions);
                });
                objectsChecked.Add(object1);
            });
            objectsChecked.Clear();
            collisions.ForEach(collision =>
            {
                CollisionHandler.PreCollide(collision.object1, collision.object2);
                CollisionHandler.PreCollide(collision.object2, collision.object1);
            });
            collisions.ForEach(collision =>
            {
                RigidBody rigidbody1 = collision.object1.RigidBody, rigidbody2 = collision.object2.RigidBody;
                (var velocityfix1, var velocityfix2) = RigidBody.ResolveCollide(collision);

                velocityFix.AddIfNotExistStruct(rigidbody1, Vector3.Zero);
                velocityFix[rigidbody1] += new Vector3(velocityfix1, 1);

                velocityFix.AddIfNotExistStruct(rigidbody2, Vector3.Zero);
                velocityFix[rigidbody2] += new Vector3(velocityfix2, 1);

                locationFix.AddIfNotExistStruct(rigidbody1, Vector3.Zero);
                var f1 = collision.side.Select(velocityfix1.DivS(velocityfix1.Abs() + velocityfix2.Abs()) * collision.depth);
                locationFix[rigidbody1] += new Vector3(f1, 1);

                locationFix.AddIfNotExistStruct(rigidbody2, Vector3.Zero);
                var f2 = collision.side.Select(velocityfix2.DivS(velocityfix1.Abs() + velocityfix2.Abs()) * collision.depth);
                locationFix[rigidbody2] += new Vector3(f2, 1);
            });
            locationFix.Consume((rigidbody, dp) =>
            {
                dp /= dp.Z;
                rigidbody.Object.Location += new Vector2(dp.X, dp.Y);
            });
            velocityFix.Consume((rigidbody, dv) =>
            {
                dv /= dv.Z;
                rigidbody.Velocity += new Vector2(dv.X, dv.Y);
            });
            collisions.Consume(collision =>
            {
                CollisionHandler.PostCollide(collision.object1, collision.object2, collision.side);
                CollisionHandler.PostCollide(collision.object2, collision.object1, collision.side.Invert());
            });
        }
    }
}
