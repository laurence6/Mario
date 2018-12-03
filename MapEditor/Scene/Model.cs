using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using static System.IO.File;

namespace MarioPirates
{
    internal class Model
    {
        public readonly string level;
        public readonly string dataFilePath;

        private LevelData Data;

        private HashMap gameObjectContainer = new HashMap();
        private List<IGameObject> gameObjectsNoRigidBody = new List<IGameObject>();

        public Model(string level)
        {
            this.level = level;
            dataFilePath = Constants.CONTENT_ROOT_PATH + Constants.LEVEL_DATA_PREFIX + level + Constants.DATA_FILE_TYPE;
            Data = new JavaScriptSerializer().Deserialize<LevelData>(ReadAllText(dataFilePath));
            Data.Objects.ForEach(o => AddGameObject(o.ToGameObject()));
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

        public void Write()
        {

        }

        public void Update()
        {
            gameObjectContainer.Rebuild();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(sortMode: SpriteSortMode.FrontToBack, samplerState: SamplerState.PointClamp, transformMatrix: Camera.Ins.Transform);
            gameObjectsNoRigidBody.ForEach(o => o.Draw(spriteBatch));
            gameObjectContainer.ForEachVisible(o => o.Draw(spriteBatch));
            spriteBatch.End();
        }
    }
}
