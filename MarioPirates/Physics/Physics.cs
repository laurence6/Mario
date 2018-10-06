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
                    ce.Object1.OnCollide(ce.Object2, ce.Side);
                    ce.Object2.OnCollide(ce.Object1, ce.Side.Invert());
                    EventManager.Instance.EnqueueEvent(ce);
                });
            }
        }

        private static void HandleCollide(in List<CollideEvent> collisions)
        {
            collisions.ForEach(ce =>
            {
                RigidBody.ResolveCollide(ce, out var v1, out var v2);

                RigidBody r1 = ce.Object1.RigidBody, r2 = ce.Object2.RigidBody;

                velocityFix.AddIfNotExist(r1, Vector3.Zero);
                velocityFix[r1] += new Vector3(v1, 1);

                velocityFix.AddIfNotExist(r2, Vector3.Zero);
                velocityFix[r2] += new Vector3(v2, 1);

                locationFix.AddIfNotExist(r1, Vector3.Zero);
                var f1 = ce.Side.Select(v1.DivS(v1.Abs() + v2.Abs()) * ce.Depth);
                locationFix[r1] += new Vector3(f1, 1);

                locationFix.AddIfNotExist(r2, Vector3.Zero);
                var f2 = ce.Side.Select(v2.DivS(v1.Abs() + v2.Abs()) * ce.Depth);
                locationFix[r2] += new Vector3(f2, 1);
            });
            locationFix.Consume(p =>
            {
                var dp = locationFix[p.Key];
                dp /= dp.Z;
                p.Key.Object.Location += new Vector2(dp.X, dp.Y);
            });
            velocityFix.Consume(p =>
            {
                var dv = p.Value;
                dv /= dv.Z;
                p.Key.Velocity += new Vector2(dv.X, dv.Y);
            });
        }
    }
}
