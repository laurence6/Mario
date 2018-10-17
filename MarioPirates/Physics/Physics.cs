using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace MarioPirates
{
    using Event;

    internal static class Physics
    {
        private static List<CollideEventArgs> collisionsFirst = new List<CollideEventArgs>();
        private static List<CollideEventArgs> collisionsOther = new List<CollideEventArgs>();

        private static HashSet<GameObjectRigidBody> objectsChecked = new HashSet<GameObjectRigidBody>();
        private static HashSet<GameObjectRigidBody> objectsNearby = new HashSet<GameObjectRigidBody>();

        private static Dictionary<RigidBody, Vector3> locationFix = new Dictionary<RigidBody, Vector3>();
        private static Dictionary<RigidBody, Vector3> velocityFix = new Dictionary<RigidBody, Vector3>();

        public static void Reset()
        {
            collisionsFirst.Clear();
            collisionsOther.Clear();
            objectsChecked.Clear();
            objectsNearby.Clear();
            velocityFix.Clear();
            locationFix.Clear();
        }

        public static void Simulate(float dt, IGameObjectContainer container)
        {
            const int nsteps = 4;
            const int nrounds = 4;

            var ddt = dt / nsteps;

            for (var s = 0; s < nsteps; s++)
            {
                container.ForEach(o => o.Step(ddt));
                container.Rebuild();

                for (var r = 0; r < nrounds; r++)
                {
                    var collisions = r == 0 ? collisionsFirst : collisionsOther;

                    container.ForEach(o1 =>
                    {
                        if (o1.RigidBody.Motion == MotionEnum.Dynamic)
                        {
                            o1.RigidBody.Grounded = null;

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

                    if (collisions.Count == 0)
                        break;
                    ResolveCollide(collisions);
                    if (r > 0)
                        collisions.Clear();
                }
                collisionsFirst.Consume(ce =>
                {
                    ce.object1.OnCollide(ce.object2, ce.side);
                    ce.object2.OnCollide(ce.object1, ce.side.Invert());
                    EventManager.RaiseEvent(EventEnum.Collide, null, ce);
                });
            }
        }

        private static void ResolveCollide(List<CollideEventArgs> collisions)
        {
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
                if (rb.Grounded.HasValue)
                    rb.Object.Location = new Vector2(rb.Object.Location.X, rb.Grounded.Value - rb.Object.Size.Y);
            });
            velocityFix.Consume((rb, dv) =>
            {
                dv /= dv.Z;
                rb.Velocity += new Vector2(dv.X, dv.Y);
                if (rb.Grounded.HasValue)
                    rb.Velocity = new Vector2(rb.Velocity.X, 0f);
            });
        }
    }
}
