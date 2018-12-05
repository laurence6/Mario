using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using static System.IO.File;

namespace MarioPirates
{
    internal sealed class Scene
    {
        public static readonly Scene Ins = new Scene();

        private Scene()
        {
        }

        public Model Model { get; private set; }

        public readonly HashMap gameObjectContainer = new HashMap();
        public readonly List<IGameObject> gameObjectsNoRigidBody = new List<IGameObject>();

        private HashSet<GameObjectRigidBody> objectsFound = new HashSet<GameObjectRigidBody>();
        private IGameObject objectSelected = null;

        private List<GameObjectParam> objectParamsAvailable = new List<GameObjectParam>();
        private List<GameObjectRigidBody> objectsAvailable = new List<GameObjectRigidBody>();

        public void Reset()
        {
            UseScene(Constants.DEFAULT_SCENE);

            objectsFound.Clear();
            objectSelected = null;

            objectParamsAvailable.Clear();
            objectsAvailable.Clear();

            objectParamsAvailable = new JavaScriptSerializer().Deserialize<List<GameObjectParam>>(ReadAllText(Constants.DATA_FILES_PATH + Constants.MAPEDITOR_DATA_FILE));
            objectParamsAvailable.ForEach(o => objectsAvailable.Add(o.ToGameObject() as GameObjectRigidBody));
            var nextLocation = new Vector2(Constants.SCREEN_WIDTH - objectsAvailable[0].Size.X * 2, objectsAvailable[0].Size.Y);
            for (var i = 0; i < objectsAvailable.Count; i++)
            {
                objectsAvailable[i].IsLocationAbsolute = true;
                objectsAvailable[i].Location = nextLocation;
                objectParamsAvailable[i].Location[0] = (int)nextLocation.X;
                objectParamsAvailable[i].Location[1] = (int)nextLocation.Y;
                nextLocation.X -= objectsAvailable[i].Size.X;
                nextLocation.X -= objectsAvailable[i].Size.X;
            }

            EventManager.Ins.Subscribe(EventEnum.KeyHold, (s, e) =>
            {
                var k = (e as KeyHoldEventArgs).key;
                switch (k)
                {
                    case Keys.Left:
                        Camera.Ins.Offset -= Constants.MAPEDITOR_MOVING_SPEED;
                        Camera.Ins.Update();
                        break;
                    case Keys.Right:
                        Camera.Ins.Offset += Constants.MAPEDITOR_MOVING_SPEED;
                        Camera.Ins.Update();
                        break;
                }
            });

            EventManager.Ins.Subscribe(EventEnum.MouseButtonDown, (s, e) => HandleMouseButtonDown((e as MouseButtonDownEventArgs).mousePosition));
            EventManager.Ins.Subscribe(EventEnum.MouseButtonUp, (s, e) => HandleMouseButtonUp((e as MouseButtonUpEventArgs).mousePosition));
            EventManager.Ins.Subscribe(EventEnum.MouseButtonHold, (s, e) => HandleMouseButtonHold((e as MouseButtonHoldEventArgs).mousePosition));
        }

        public void UseScene(string scene)
        {
            gameObjectContainer.Reset();
            gameObjectsNoRigidBody.Clear();
            Model = new Model(scene);
            Model.Objects.ForEach(AddGameObject);
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

        public void Update()
        {
            gameObjectContainer.Rebuild();
            objectsAvailable.ForEach(o => o.RigidBody.UpdateBound());
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(sortMode: SpriteSortMode.FrontToBack, samplerState: SamplerState.PointClamp, transformMatrix: Camera.Ins.Transform);
            gameObjectsNoRigidBody.ForEach(o => o.Draw(spriteBatch));
            gameObjectContainer.ForEachVisible(o => o.Draw(spriteBatch));
            objectsAvailable.ForEach(o => o.Draw(spriteBatch));
            spriteBatch.End();
        }

        private void HandleMouseButtonDown(Point pos)
        {
            var point = new Rectangle(Camera.Ins.ScreenToWorld(pos), Point.Zero);
            objectSelected = null;

            for (var i = 0; i < objectsAvailable.Count; i++)
                if (objectsAvailable[i].RigidBody.Bound.Intersects(point))
                {
                    var obj = Model.AddGameObject(objectParamsAvailable[i].Copy());
                    obj.Location = Camera.Ins.ScreenToWorld(obj.Location);
                    AddGameObject(obj);
                    objectSelected = obj;
                    return;
                }

            objectsFound.Clear();
            gameObjectContainer.Find(point, objectsFound);
            foreach (var o in objectsFound)
                if (o.RigidBody.Bound.Intersects(point))
                {
                    objectSelected = o;
                    return;
                }
        }

        private void HandleMouseButtonUp(Point pos)
        {
            if (objectSelected == null)
                return;
            if (pos.Y < 0 || pos.Y > Constants.SCREEN_HEIGHT)
            {
                RemoveGameObject(objectSelected);
                Model.RemoveGameObject(objectSelected);
            }
            objectSelected = null;
        }

        private void HandleMouseButtonHold(Point pos)
        {
            if (objectSelected != null)
                objectSelected.Location = Align(Camera.Ins.ScreenToWorld(pos - objectSelected.Size.Div(2))).ToVector2();
        }

        private static Point Align(Point pos)
        {
            pos.X &= Constants.MAPEDITOR_ALIGNMENT_MASK;
            pos.Y &= Constants.MAPEDITOR_ALIGNMENT_MASK;
            return pos;
        }
    }
}
