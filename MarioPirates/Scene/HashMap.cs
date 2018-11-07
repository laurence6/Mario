using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarioPirates
{
    internal class HashMap
    {
        public const ulong mask = ~(Constants.HASH_MAP_SIZE - 1);

        private HashSet<GameObjectRigidBody> objects = new HashSet<GameObjectRigidBody>();

        private HashSet<ulong> bucketKeys = new HashSet<ulong>();
        private Dictionary<ulong, HashSet<GameObjectRigidBody>> buckets = new Dictionary<ulong, HashSet<GameObjectRigidBody>>();
        private HashSet<GameObjectRigidBody> objectsVisible = new HashSet<GameObjectRigidBody>();

        public void Reset()
        {
            objects.Clear();
            bucketKeys.Clear();
            buckets.Clear();
            objectsVisible.Clear();
        }

        public void Add(GameObjectRigidBody o)
        {
            objects.Add(o);
        }

        public void Remove(GameObjectRigidBody o)
        {
            objects.Remove(o);
            Apply(o.RigidBody.Bound, s => s.Remove(o));
        }

        public void Rebuild()
        {
            bucketKeys.Clear();
            objectsVisible.Clear();

            Apply(Camera.Ins.VisibleArea, k => bucketKeys.Add(k));

            buckets.Keys.ToList().ForEach(k => (!bucketKeys.Contains(k)).Then(() => buckets.Remove(k)));
            buckets.ForEach((k, s) => s.Clear());
            bucketKeys.ForEach(k => buckets.AddIfNotExist(k));

            ForEach(o => Apply(o.RigidBody.Bound, s => { s.Add(o); objectsVisible.Add(o); }));
        }

        public void Find(Rectangle bound, HashSet<GameObjectRigidBody> objectsNearby)
        {
            Apply(bound, s => objectsNearby.UnionWith(s));
        }

        public void ForEachVisible(Action<GameObjectRigidBody> f)
        {
            objectsVisible.ForEach(f);
        }

        public void ForEach(Action<GameObjectRigidBody> f)
        {
            objects.ForEach(f);
        }

        private void Apply(Rectangle bound, Action<HashSet<GameObjectRigidBody>> f)
        {
            Apply(bound, k => buckets.ContainsKey(k).Then(() => f(buckets[k])));
        }

        private void Apply(Rectangle bound, Action<ulong> f)
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
