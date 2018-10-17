using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace MarioPirates
{
    internal interface IGameObjectContainer
    {
        void Reset();

        void Add(GameObjectRigidBody o);
        void Remove(GameObjectRigidBody o);
        void Rebuild();
        void Find(Rectangle bound, HashSet<GameObjectRigidBody> objectsNearby);
        void ForEach(Action<GameObjectRigidBody> f);
    }
}
