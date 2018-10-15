using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace MarioPirates
{
    using Event;

    internal static class Physics
    {
        private static List<CollideEvent> collisionsFirst = new List<CollideEvent>();
        private static List<CollideEvent> collisionsOther = new List<CollideEvent>();

        private static Dictionary<RigidBody, Vector3> locationFix = new Dictionary<RigidBody, Vector3>();

        private static Dictionary<RigidBody, Vector3> velocityFix = new Dictionary<RigidBody, Vector3>();

        public static void Reset()
        {
            collisionsFirst.Clear();
            collisionsOther.Clear();
            velocityFix.Clear();
            locationFix.Clear();
        }

        public static void Simulate(float dt, in List<GameObject> gameObjects)
        {
            const float S = 4f;
            const int R = 5;

            var ddt = dt / S;

            for (var s = 0f; s < S; s++)
            {
                gameObjects.ForEach(o => o.Step(ddt));

                for (var r = 0; r < R; r++)
                {
                    var collisions = r == 0 ? collisionsFirst : collisionsOther;

                    foreach (var o1 in gameObjects)
                        if (o1.IsStatic)
                            foreach (var o2 in gameObjects)
                                if (!o2.IsStatic)
                                    RigidBody.DetectCollide(o1, o2, collisions);
                    for (var i = 0; i < gameObjects.Count; i++)
                        if (!gameObjects[i].IsStatic)
                            for (var j = i + 1; j < gameObjects.Count; j++)
                                if (!gameObjects[j].IsStatic)
                                    RigidBody.DetectCollide(gameObjects[i], gameObjects[j], collisions);

                    if (collisions.Count > 0)
                        HandleCollide(collisions);
                    if (r > 0)
                        collisions.Clear();
                }

                collisionsFirst.Consume(ce =>
                {
                    ce.object1.OnCollide(ce.object2, ce.side);
                    ce.object2.OnCollide(ce.object1, ce.side.Invert());
                    EventManager.EnqueueEvent(ce);
                });
            }
        }

        private static void HandleCollide(in List<CollideEvent> collisions)
        {
            collisions.ForEach(ce =>
            {
                RigidBody.ResolveCollide(ce, out var v1, out var v2);

                RigidBody r1 = ce.object1.RigidBody, r2 = ce.object2.RigidBody;

                velocityFix.AddIfNotExist(r1, Vector3.Zero);
                velocityFix[r1] += new Vector3(v1, 1);

                velocityFix.AddIfNotExist(r2, Vector3.Zero);
                velocityFix[r2] += new Vector3(v2, 1);

                locationFix.AddIfNotExist(r1, Vector3.Zero);
                var f1 = ce.side.Select(v1.DivS(v1.Abs() + v2.Abs()) * ce.depth);
                locationFix[r1] += new Vector3(f1, 1);

                locationFix.AddIfNotExist(r2, Vector3.Zero);
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
        }
    }
}
