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
        private List<GameObject> gameObjectsStatic = new List<GameObject>();
        private List<GameObject> gameObjectToDestory = new List<GameObject>();

        private Scene() { }

        public void Reset()
        {
            gameObjects.Clear();
            gameObjectsStatic.Clear();
            gameObjectToDestory.Clear();

            EventManager.Instance.Subscribe(e => gameObjectToDestory.AddIfNotExist(((GameObjectDestroyEvent)e).Object), EventEnum.GameObjectDestroy);

            new JavaScriptSerializer().Deserialize<List<GameObjectParam>>(ReadAllText("Scene\\LevelData.json"))
                .ForEach(o => AddGameObject(o.ToGameObject()));
        }

        public void AddGameObject(GameObject o, bool isStatic = false) =>
            (isStatic ? gameObjectsStatic : gameObjects).Add(o);

        public void Update(float dt)
        {
            Physics.Simulate(dt, in gameObjects, in gameObjectsStatic);
            gameObjectToDestory.ForEach(o => { gameObjectsStatic.Remove(o); gameObjects.Remove(o); });
            gameObjectToDestory.Clear();
        }

        public void Draw(SpriteBatch spriteBatch, Dictionary<string, Texture2D> textures)
        {
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            gameObjectsStatic.ForEach(o => o.Draw(spriteBatch, textures));
            gameObjects.ForEach(o => o.Draw(spriteBatch, textures));
            spriteBatch.End();
        }
    }
}
