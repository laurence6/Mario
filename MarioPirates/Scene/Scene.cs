﻿using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using static System.IO.File;

namespace MarioPirates
{
    using Event;

    internal sealed class Scene
    {
        public static readonly Scene Instance = new Scene();

        private IGameObjectContainer gameObjectContainer = new HashMap();
        private List<GameObject> gameObjectsNoBound = new List<GameObject>();

        private List<GameObjectParam> gameObjectToCreate = new List<GameObjectParam>();
        private HashSet<GameObject> gameObjectToDestory = new HashSet<GameObject>();

        private Scene() { }

        public void Reset()
        {
            gameObjectContainer.Reset();
            gameObjectsNoBound.Clear();
            gameObjectToCreate.Clear();
            gameObjectToDestory.Clear();

            EventManager.Subscribe(EventEnum.GameObjectCreate, (s, e) => AddGameObject((e as GameObjectCreateEventArgs).param.ToGameObject()));
            EventManager.Subscribe(EventEnum.GameObjectDestroy, (s, e) => RemoveGameObject((e as GameObjectDestroyEventArgs).Object));

            new JavaScriptSerializer().Deserialize<List<GameObjectParam>>(ReadAllText("Content\\LevelData.json"))
                .ForEach(o => EventManager.RaiseEvent(EventEnum.GameObjectCreate, this, new GameObjectCreateEventArgs(o)));
        }

        public void AddGameObject(GameObject o)
        {
            if (o is GameObjectRigidBody or)
                gameObjectContainer.Add(or);
            else
                gameObjectsNoBound.Add(o);
        }

        public void RemoveGameObject(GameObject o)
        {
            if (o is GameObjectRigidBody or)
                gameObjectContainer.Remove(or);
            else
                gameObjectsNoBound.Remove(o);
        }

        public void Update(float dt)
        {
            Physics.Simulate(dt, gameObjectContainer);

            gameObjectsNoBound.ForEach(o => o.Update(dt));
            gameObjectContainer.ForEach(o => o.Update(dt));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            gameObjectsNoBound.ForEach(o => o.Draw(spriteBatch));
            gameObjectContainer.ForEach(o => o.Draw(spriteBatch));
            spriteBatch.End();
        }
    }
}
