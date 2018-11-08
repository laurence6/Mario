using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using static System.IO.File;

namespace MarioPirates
{
    internal sealed class Scene
    {
        public class SceneData
        {
            public readonly string level;
            private HashMap gameObjectContainer = new HashMap();
            private List<IGameObject> gameObjectsNoRigidBody = new List<IGameObject>();

            public SceneData(string level)
            {
                this.level = level;
            }

            public void Reset()
            {
                gameObjectContainer.Reset();
                gameObjectsNoRigidBody.Clear();

                AddGameObject(new Background());
                AddGameObject(new VirtualPlane(0f, Constants.SCREEN_HEIGHT - 1));
                AddGameObject(new VirtualWall(0f, 0f));
                AddGameObject(new VirtualWall(Constants.SCREEN_WIDTH - Constants.VIRTUAL_WALL_WIDTH, 0f));
                new JavaScriptSerializer().Deserialize<List<GameObjectParam>>(ReadAllText("Content\\LevelData_" + level + ".json"))
                    .ForEach(o => EventManager.Ins.RaiseEvent(EventEnum.GameObjectCreate, this, new GameObjectCreateEventArgs(o.ToGameObject())));

                var sceneEndBound = 0f;
                gameObjectContainer.ForEachVisible(o => sceneEndBound = sceneEndBound.Max(o.RigidBody.Bound.Right));
                var endWall = new VirtualWall(sceneEndBound - Constants.SCREEN_WIDTH / 2, 0f)
                {
                    IsLocationAbsolute = false
                };
                AddGameObject(endWall);
            }

            public void AddGameObject(IGameObject o)
            {
                if (o is GameObjectRigidBody objectRigidBody)
                    gameObjectContainer.Add(objectRigidBody);
                else
                    gameObjectsNoRigidBody.Add(o);
            }

            public void RemoveGameObject(IGameObject o)
            {
                if (o is GameObjectRigidBody objectRigidBody)
                    gameObjectContainer.Remove(objectRigidBody);
                else
                    gameObjectsNoRigidBody.Remove(o);
            }

            public void Update(float dt)
            {
                Physics.Simulate(dt, gameObjectContainer);

                gameObjectsNoRigidBody.ForEach(o => o.Update(dt));
                gameObjectContainer.ForEachVisible(o => o.Update(dt));
            }

            public void Draw(SpriteBatch spriteBatch)
            {
                spriteBatch.Begin(samplerState: SamplerState.PointClamp, transformMatrix: Camera.Ins.Transform);
                gameObjectsNoRigidBody.ForEach(o => o.Draw(spriteBatch));
                gameObjectContainer.ForEachVisible(o => o.Draw(spriteBatch));
                spriteBatch.End();
            }
        }

        public static readonly Scene Ins = new Scene();

        private Dictionary<string, SceneData> scenes = new Dictionary<string, SceneData>();
        public SceneData ActiveScene { get; private set; }
        private Action unsubscribe = null;

        private Scene()
        {
        }

        public void Reset()
        {
            scenes.Clear();
            Constants.AVAILABLE_SCENES.ForEach(level => scenes.Add(level, new SceneData(level)));
            Active(Constants.DEFAULT_SCENE);
        }

        public void ResetActive() => ActiveScene.Reset();

        public void Active(string level)
        {
            unsubscribe?.Invoke();
            unsubscribe = null;

            ActiveScene = scenes[level];

            unsubscribe += EventManager.Ins.Subscribe(EventEnum.GameObjectCreate, (s, e) => ActiveScene.AddGameObject((e as GameObjectCreateEventArgs).Object));
            unsubscribe += EventManager.Ins.Subscribe(EventEnum.GameObjectDestroy, (s, e) =>
            {
                var eventArgs = e as GameObjectDestroyEventArgs;
                (eventArgs.Object as IDisposable)?.Dispose();
                ActiveScene.RemoveGameObject(eventArgs.Object);
            });
        }

        public void Update(float dt) => ActiveScene.Update(dt);

        public void Draw(SpriteBatch spriteBatch) => ActiveScene.Draw(spriteBatch);
    }
}
