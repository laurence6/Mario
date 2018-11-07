using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using static System.IO.File;

namespace MarioPirates
{
    internal sealed class Scene
    {
        private class SceneData
        {
            private readonly string level;
            private HashMap gameObjectContainer = new HashMap();
            private List<IGameObject> gameObjectsNoRigidBody = new List<IGameObject>();

            public SceneData(string level)
            {
                this.level = level;
                HUD.Ins.UpdateLevel(level);
            }

            public void Reset()
            {
                gameObjectContainer.Reset();
                gameObjectsNoRigidBody.Clear();

                AddGameObject(new Background());
                AddGameObject(new VirtualPlane(0f, Constants.SCREEN_HEIGHT + 1));
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
                if (o is GameObjectRigidBody or)
                    gameObjectContainer.Add(or);
                else
                    gameObjectsNoRigidBody.Add(o);
            }

            public void RemoveGameObject(IGameObject o)
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
        private SceneData activeScene = null;
        private Action unsubscribe = null;

        private Scene()
        {
        }

        public void Reset()
        {
            scenes.Clear();
            new string[] { "1" }.ForEach(level => scenes.Add(level, new SceneData(level)));
            Active("1");
        }

        public void ResetActive() => activeScene.Reset();

        public void Active(string level)
        {
            unsubscribe?.Invoke();
            unsubscribe = null;

            activeScene = scenes[level];

            unsubscribe += EventManager.Ins.Subscribe(EventEnum.GameObjectCreate, (s, e) => activeScene.AddGameObject((e as GameObjectCreateEventArgs).Object));
            unsubscribe += EventManager.Ins.Subscribe(EventEnum.GameObjectDestroy, (s, e) =>
            {
                var eventArgs = e as GameObjectDestroyEventArgs;
                (eventArgs.Object as IDisposable)?.Dispose();
                activeScene.RemoveGameObject(eventArgs.Object);
            });
        }

        public void Update(float dt) => activeScene.Update(dt);

        public void Draw(SpriteBatch spriteBatch) => activeScene.Draw(spriteBatch);
    }
}
