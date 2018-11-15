using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace MarioPirates
{
    internal class HashMap
    {
        public const ulong mask = ~(Constants.HASH_MAP_SIZE - 1);

        private HashSet<GameObjectRigidBody> objects = new HashSet<GameObjectRigidBody>();

        private Dictionary<ulong, HashSet<GameObjectRigidBody>> buckets = new Dictionary<ulong, HashSet<GameObjectRigidBody>>();
        private List<GameObjectRigidBody> objectsVisible = new List<GameObjectRigidBody>();

        private List<ulong> keys = new List<ulong>();

        public void Reset()
        {
            objects.Clear();
            buckets.Clear();
            objectsVisible.Clear();
            keys.Clear();
        }

        public void Add(GameObjectRigidBody o)
        {
            objects.Add(o);
        }

        public void Remove(GameObjectRigidBody o)
        {
            Apply(o.RigidBody.Bound, k => buckets.ContainsKey(k).Then(() => buckets[k].Remove(o)));
            objects.Remove(o);
        }

        public void Rebuild()
        {
            Apply(Camera.Ins.VisibleArea, buckets.AddIfNotExist);

            objectsVisible.Clear();

            foreach (var pair in buckets)
                pair.Value.Clear();

            foreach (var o in objects)
            {
                var visiblePart = Rectangle.Intersect(o.RigidBody.Bound, Camera.Ins.VisibleArea);
                if (!visiblePart.IsEmpty)
                {
                    objectsVisible.Add(o);
                    Apply(visiblePart, keys.Add);
                    foreach (var k in keys)
                        buckets[k].Add(o);
                    keys.Clear();
                }
            }
        }

        public void Find(Rectangle bound, HashSet<GameObjectRigidBody> objectsNearby)
        {
            Apply(bound, k => buckets.ContainsKey(k).Then(() => objectsNearby.UnionWith(buckets[k])));
        }

        public void ForEachVisible(Action<GameObjectRigidBody> f)
        {
            objectsVisible.ForEach(f);
        }

        private static void Apply(Rectangle bound, Action<ulong> f)
        {
            (var minX, var minY) = Hash(bound.Location);
            (var maxX, var maxY) = Hash(bound.Location + bound.Size);
            for (var x = minX; x <= maxX; x += Constants.HASH_MAP_SIZE)
                for (var y = minY; y <= maxY; y += Constants.HASH_MAP_SIZE)
                    f((x << Constants.INT_SIZE) | y);
        }

        private static (ulong, ulong) Hash(Point p)
        {
            var x = p.X - (long)int.MinValue;
            var y = p.Y - (long)int.MinValue;
            return ((ulong)x & mask, (ulong)y & mask);
        }
    }
}
