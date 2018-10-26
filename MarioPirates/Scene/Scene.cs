using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using static System.IO.File;

namespace MarioPirates
{
    internal sealed class Scene
    {
        public static readonly Scene Ins = new Scene();

        private IGameObjectContainer gameObjectContainer = new HashMap();
        private List<GameObject> gameObjectsNoRigidBody = new List<GameObject>();
        private List<GameObject> gameObjectsAbsLocation = new List<GameObject> { new Background(0, 0) };

        private Scene()
        {
        }

        public void Reset()
        {
            gameObjectContainer.Reset();
            gameObjectsNoRigidBody.Clear();

            EventManager.Ins.Subscribe(EventEnum.GameObjectCreate, (s, e) => AddGameObject((e as GameObjectCreateEventArgs).Object));
            EventManager.Ins.Subscribe(EventEnum.GameObjectDestroy, (s, e) => RemoveGameObject((e as GameObjectDestroyEventArgs).Object));

            new JavaScriptSerializer().Deserialize<List<GameObjectParam>>(ReadAllText("Content\\LevelData.json"))
                .ForEach(o => EventManager.Ins.RaiseEvent(EventEnum.GameObjectCreate, this, new GameObjectCreateEventArgs(o.ToGameObject())));
        }

        public void AddGameObject(GameObject o)
        {
            if (o is GameObjectRigidBody or)
                gameObjectContainer.Add(or);
            else
                gameObjectsNoRigidBody.Add(o);
        }

        public void RemoveGameObject(GameObject o)
        {
            if (o is GameObjectRigidBody or)
                gameObjectContainer.Remove(or);
            else
                gameObjectsNoRigidBody.Remove(o);
        }

        public void Update(float dt)
        {
            Physics.Simulate(dt, gameObjectContainer);

            gameObjectsNoRigidBody.ForEach(o => o.Update(dt));
            gameObjectContainer.ForEach(o => o.Update(dt));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            gameObjectsAbsLocation.ForEach(o => o.Draw(spriteBatch));
            spriteBatch.End();
            spriteBatch.Begin(samplerState: SamplerState.PointClamp, transformMatrix: Camera.Ins.Transform);
            gameObjectsNoRigidBody.ForEach(o => o.Draw(spriteBatch));
            gameObjectContainer.ForEach(o => o.Draw(spriteBatch));
            spriteBatch.End();
        }
    }
}
