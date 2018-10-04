using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace MarioPirates
{
    using Event;

    internal static class Physics
    {
        private static List<CollideEvent> collisions = new List<CollideEvent>();
        private static Dictionary<RigidBody, Vector3> velocityFix = new Dictionary<RigidBody, Vector3>();
        private static Dictionary<RigidBody, Vector3> locationFix = new Dictionary<RigidBody, Vector3>();

        public static void Reset()
        {
            collisions.Clear();
            velocityFix.Clear();
            locationFix.Clear();
        }

        public static void Simulate(float dt, in List<GameObject> gameObjects)
        {
            const float N = 4f;
            const int R = 5;

            var ddt = dt / N;

            for (var n = 0f; n < N; n++)
            {
                gameObjects.ForEach(o => o.Step(ddt));

                for (var r = 0; ; r++)
                {
                    foreach (var o1 in gameObjects)
                        if (o1.IsStatic)
                            foreach (var o2 in gameObjects)
                                if (!o2.IsStatic)
                                    DetectCollide(o1, o2);
                    for (var i = 0; i < gameObjects.Count; i++)
                        if (!gameObjects[i].IsStatic)
                            for (var j = i + 1; j < gameObjects.Count; j++)
                                if (!gameObjects[j].IsStatic)
                                    DetectCollide(gameObjects[i], gameObjects[j]);

                    if (r > R || collisions.Count == 0)
                        break;

                    HandleCollide(r == 0);
                }
            }
        }

        private static void DetectCollide(GameObject o1, GameObject o2)
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

                        var relVel = r2.Velocity - r1.Velocity;
                        if (relVel.Y <= 0)
                            side &= ~CollisionSide.Top;
                        if (relVel.Y >= 0)
                            side &= ~CollisionSide.Bottom;
                        if (relVel.X <= 0)
                            side &= ~CollisionSide.Left;
                        if (relVel.X >= 0)
                            side &= ~CollisionSide.Right;
                        if (side != CollisionSide.None)
                        {
                            if (ints.Width > ints.Height)
                            {
                                side &= CollisionSide.TopBottom;
                                depth = Math.Abs(ints.Height);
                            }
                            else
                            {
                                side &= CollisionSide.LeftRight;
                                depth = Math.Abs(ints.Width);
                            }

                            if ((r1.CollideSideMask & side) != 0 && (r2.CollideSideMask & side.Invert()) != 0)
                                collisions.Add(new CollideEvent(o1, o2, side, depth));
                        }
                    }
                }
            }
        }

        private static void HandleCollide(bool sendOncollide)
        {
            collisions.ForEach(ce =>
            {
                ResolveCollide(ce, out var v1, out var v2);

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

            foreach (var p in velocityFix)
            {
                var v = p.Value;
                v /= v.Z;
                var f = locationFix[p.Key];
                f /= f.Z;
                p.Key.Velocity += new Vector2(v.X, v.Y);
                p.Key.Object.Location += new Vector2(f.X, f.Y);
            }
            velocityFix.Clear();
            locationFix.Clear();

            if (sendOncollide)
                collisions.ForEach(ce =>
                {
                    ce.Object1.OnCollide(ce.Object2, ce.Side);
                    ce.Object2.OnCollide(ce.Object1, ce.Side.Invert());
                    EventManager.Instance.EnqueueEvent(ce);
                });

            collisions.Clear();
        }

        private static void ResolveCollide(CollideEvent ce, out Vector2 v1, out Vector2 v2)
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
                / (1f / o1.Mass + 1f / o2.Mass)
                * normal;
            v1 = (o1.CoR + 1f) / o1.Mass * dp;
            v2 = (o2.CoR + 1f) / o2.Mass * -dp;
        }
    }
}
