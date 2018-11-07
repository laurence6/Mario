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
            container.ForEachVisible(o1 =>
            {
                if (o1.RigidBody.Motion == MotionEnum.Dynamic)
                {
                    o1.RigidBody.Grounded = false;

                    if (o1.RigidBody.Velocity.Y >= 0f)
                    {
                        var bound = o1.RigidBody.Bound;
                        var potentialSupportUpper = new Rectangle(bound.Left, bound.Bottom + 1, bound.Width, 1);
                        container.Find(potentialSupportUpper, potentialSupport);
                        foreach (var o2 in potentialSupport)
                        {
                            if (o1.RigidBody.CollisionLayerMask.HasOne(o2.RigidBody.CollisionLayerMask))
                                if (o1.RigidBody.CollisionSideMask.HasOne(CollisionSide.Bottom) && o2.RigidBody.CollisionSideMask.HasOne(CollisionSide.Top))
                                    if (o2.RigidBody.Bound.Intersects(potentialSupportUpper))
                                    {
                                        o1.RigidBody.Grounded = true;
                                        collisions.Add(new CollideEventArgs(o1, o2, CollisionSide.Bottom, 0f));
                                    }
                        }
                        potentialSupport.Clear();
                    }
                }
            });
            collisions.ForEach(ce =>
            {
                CollisionHandler.Ins.PreCollide(ce.object1, ce.object2, ce.side);
                CollisionHandler.Ins.PreCollide(ce.object2, ce.object1, ce.side.Invert());
            });
            collisions.ForEach(ce =>
            {
                ce.object1.RigidBody.Velocity = new Vector2(ce.object1.RigidBody.Velocity.X, 0f);
            });
            collisions.Consume(ce =>
            {
                CollisionHandler.Ins.PostCollide(ce.object1, ce.object2, ce.side);
                CollisionHandler.Ins.PostCollide(ce.object2, ce.object1, ce.side.Invert());
            });

        }

        private static void SimulateCollision(HashMap container)
        {
            container.Rebuild();
            container.ForEachVisible(o1 =>
            {
                if (o1.RigidBody.Motion == MotionEnum.Dynamic)
                {
                    container.Find(o1.RigidBody.Bound, objectsNearby);
                    objectsNearby.Consume(o2 =>
                    {
                        if (o1 != o2 && !objectsChecked.Contains(o2))
                            RigidBody.DetectCollide(o1, o2, collisions);
                    });
                    objectsChecked.Add(o1);
                }
            });
            objectsChecked.Clear();
            collisions.ForEach(ce =>
            {
                CollisionHandler.Ins.PreCollide(ce.object1, ce.object2, ce.side);
                CollisionHandler.Ins.PreCollide(ce.object2, ce.object1, ce.side.Invert());
            });
            collisions.ForEach(ce =>
            {
                RigidBody r1 = ce.object1.RigidBody, r2 = ce.object2.RigidBody;
                (var v1, var v2) = RigidBody.ResolveCollide(ce);

                velocityFix.AddIfNotExistStruct(r1, Vector3.Zero);
                velocityFix[r1] += new Vector3(v1, 1);

                velocityFix.AddIfNotExistStruct(r2, Vector3.Zero);
                velocityFix[r2] += new Vector3(v2, 1);

                locationFix.AddIfNotExistStruct(r1, Vector3.Zero);
                var f1 = ce.side.Select(v1.DivS(v1.Abs() + v2.Abs()) * ce.depth);
                locationFix[r1] += new Vector3(f1, 1);

                locationFix.AddIfNotExistStruct(r2, Vector3.Zero);
                var f2 = ce.side.Select(v2.DivS(v1.Abs() + v2.Abs()) * ce.depth);
                locationFix[r2] += new Vector3(f2, 1);
            });
            locationFix.Consume((rb, dp) =>
            {
                dp /= dp.Z;
                rb.Object.Location += new Vector2(dp.X, dp.Y);
            });
            velocityFix.Consume((rb, dv) =>
            {
                dv /= dv.Z;
                rb.Velocity += new Vector2(dv.X, dv.Y);
            });
            collisions.Consume(ce =>
            {
                CollisionHandler.Ins.PostCollide(ce.object1, ce.object2, ce.side);
                CollisionHandler.Ins.PostCollide(ce.object2, ce.object1, ce.side.Invert());
            });
        }
    }
}
