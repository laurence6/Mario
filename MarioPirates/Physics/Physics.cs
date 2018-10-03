using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace MarioPirates
{
    using Event;

    internal static class Physics
    {
        private static List<CollideEvent> collisions = new List<CollideEvent>();
        private static Dictionary<BaseRigidBody, Vector3> newVelocity = new Dictionary<BaseRigidBody, Vector3>();
        private static Dictionary<BaseRigidBody, Vector3> fix = new Dictionary<BaseRigidBody, Vector3>();

        public static void Reset()
        {
            collisions.Clear();
            newVelocity.Clear();
            fix.Clear();
        }

        public static void Simulate(float dt, in List<GameObject> gameObjects, in List<GameObject> gameObjectsStatic)
        {
            const float N = 4f;
            var ddt = dt / N;

            for (var n = 0f; n < N; n++)
            {
                gameObjects.ForEach(o => o.Step(ddt));
                gameObjectsStatic.ForEach(o => o.Step(ddt));

                foreach (var objStatic in gameObjectsStatic)
                    foreach (var obj in gameObjects)
                        TestCollide(objStatic, obj);
                for (var i = 0; i < gameObjects.Count; i++)
                    for (var j = i + 1; j < gameObjects.Count; j++)
                        TestCollide(gameObjects[i], gameObjects[j]);

                HandleCollide();
            }

            gameObjects.ForEach(o => o.Update(dt));
            gameObjectsStatic.ForEach(o => o.Update(dt));
        }

        private static void TestCollide(GameObject o1, GameObject o2)
        {
            if (o1.RigidBody != null && o2.RigidBody != null)
                if ((o1.RigidBody.CollideMask & o2.RigidBody.CollideMask) != 0)
                {
                    var b1 = o1.RigidBody.Bound;
                    var b2 = o2.RigidBody.Bound;
                    Rectangle.Intersect(ref b1, ref b2, out var ints);
                    if (!ints.IsEmpty)
                    {
                        var depth = ints.Width > ints.Height
                            ? b1.Center.Y > b2.Center.Y ? new Vector2(0, -ints.Height) : new Vector2(0, ints.Height)
                            : b1.Center.X > b2.Center.X ? new Vector2(-ints.Width, 0) : new Vector2(ints.Width, 0);
                        collisions.Add(new CollideEvent(o1, o2, depth));
                    }
                }
        }

        private static void HandleCollide()
        {
            collisions.ForEach(ce =>
            {
                var r1 = ce.Object1.RigidBody;
                var r2 = ce.Object2.RigidBody;

                ResolveCollide(r1, r2, ce.Depth, out var v1, out var v2);

                newVelocity.AddIfNotExist(r1, Vector3.Zero);
                newVelocity[r1] += new Vector3(v1, 1);

                newVelocity.AddIfNotExist(r2, Vector3.Zero);
                newVelocity[r2] += new Vector3(v2, 1);

                fix.AddIfNotExist(r1, Vector3.Zero);
                fix[r1] += new Vector3(v1.Abs().DivS(v1.Abs() + v2.Abs()) * -ce.Depth, 1);

                fix.AddIfNotExist(r2, Vector3.Zero);
                fix[r2] += new Vector3(v2.Abs().DivS(v1.Abs() + v2.Abs()) * ce.Depth, 1);
            });
            foreach (var p in newVelocity)
            {
                var v = p.Value;
                v /= v.Z;
                var f = fix[p.Key];
                f /= f.Z;
                p.Key.Velocity += new Vector2(v.X, v.Y);
                p.Key.Object.Location += new Vector2(f.X, f.Y);
            }
            newVelocity.Clear();
            fix.Clear();

            collisions.ForEach(ce =>
            {
                ce.Object1.OnCollide(ce.Object2, GetCollisionSide(ce.Depth));
                ce.Object2.OnCollide(ce.Object1, GetCollisionSide(-ce.Depth));
                EventManager.Instance.EnqueueEvent(ce);
            });
            collisions.Clear();
        }

        private static void ResolveCollide(BaseRigidBody o1, BaseRigidBody o2, Vector2 depth, out Vector2 v1, out Vector2 v2)
        {
            var e = 0.5f;
            var normal = depth;
            normal.Normalize();
            var dp = (e + 1f) * (o2.Velocity * normal - o1.Velocity * normal)
                / (1f / o1.Mass + 1f / o2.Mass)
                * normal;
            v1 = dp / o1.Mass;
            v2 = -dp / o2.Mass;
        }

        private static CollisionSide GetCollisionSide(Vector2 depth) =>
            depth.X != 0
            ? depth.X > 0 ? CollisionSide.Right : CollisionSide.Left
            : depth.Y > 0 ? CollisionSide.Bottom : CollisionSide.Top;
    }
}
