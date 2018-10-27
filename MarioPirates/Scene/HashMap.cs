using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace MarioPirates
{
    internal class HashMap : IGameObjectContainer
    {
        public const ulong size = 64;
        public const ulong mask = ~(size - 1);

        private HashSet<GameObjectRigidBody> objects = new HashSet<GameObjectRigidBody>();
        private Dictionary<ulong, HashSet<GameObjectRigidBody>> buckets = new Dictionary<ulong, HashSet<GameObjectRigidBody>>();

        public void Reset()
        {
            objects.Clear();
            buckets.Clear();
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
            buckets.Clear();
            ForEach(o => Apply(o.RigidBody.Bound, s => s.Add(o)));
        }

        public void Find(Rectangle bound, HashSet<GameObjectRigidBody> objectsNearby)
        {
            Apply(bound, s => objectsNearby.UnionWith(s));
        }

        public void ForEach(Action<GameObjectRigidBody> f)
        {
            objects.ForEach(f);
        }

        private void Apply(Rectangle bound, Action<HashSet<GameObjectRigidBody>> f)
        {
            (var minX, var minY) = Hash(bound.Location);
            (var maxX, var maxY) = Hash(bound.Location + bound.Size);
            for (var x = minX; x <= maxX; x += size)
                for (var y = minY; y <= maxY; y += size)
                {
                    var k = (x << 32) | y;
                    buckets.AddIfNotExist(k);
                    f(buckets[k]);
                }
        }

        private static (ulong, ulong) Hash(Point p)
        {
            var x = p.X - (long)int.MinValue;
            var y = p.Y - (long)int.MinValue;
            return ((ulong)x & mask, (ulong)y & mask);
        }
    }
}
