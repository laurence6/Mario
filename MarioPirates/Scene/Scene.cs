using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using static System.IO.File;

namespace MarioPirates
{
    using Event;

    internal sealed class Scene
    {
        public static Scene Instance { get; } = new Scene();

        private List<GameObject> gameObjects = new List<GameObject>();

        private List<GameObjectParam> gameObjectToCreate = new List<GameObjectParam>();
        private List<GameObject> gameObjectToDestory = new List<GameObject>();

        private Scene() { }

        public void Reset()
        {
            gameObjects.Clear();
            gameObjectToCreate.Clear();
            gameObjectToDestory.Clear();

            EventManager.Instance.Subscribe(e => gameObjectToCreate.Add(((GameObjectCreateEvent)e).Param), EventEnum.GameObjectCreate);
            EventManager.Instance.Subscribe(e => gameObjectToDestory.AddIfNotExist(((GameObjectDestroyEvent)e).Object), EventEnum.GameObjectDestroy);

            new JavaScriptSerializer().Deserialize<List<GameObjectParam>>(ReadAllText("Scene\\LevelData.json"))
                .ForEach(o => EventManager.Instance.TriggerEvent(new GameObjectCreateEvent(o)));
        }

        public void AddGameObject(GameObject o) => gameObjects.Add(o);

        public void Update(float dt)
        {
            Physics.Simulate(dt, in gameObjects);

            gameObjectToDestory.ForEach(o => gameObjects.Remove(o));
            gameObjectToDestory.Clear();
            gameObjectToCreate.ForEach(p => AddGameObject(p.ToGameObject()));
            gameObjectToCreate.Clear();

            gameObjects.ForEach(o => o.Update(dt));
        }

        public void Draw(SpriteBatch spriteBatch, Dictionary<string, Texture2D> textures)
        {
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            gameObjects.ForEach(o => o.Draw(spriteBatch, textures));
            spriteBatch.End();
        }
    }
}
