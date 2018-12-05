using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

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

        public void Reset()
        {
            UseScene(Constants.DEFAULT_SCENE);

            objectsFound.Clear();
            objectSelected = null;

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
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(sortMode: SpriteSortMode.FrontToBack, samplerState: SamplerState.PointClamp, transformMatrix: Camera.Ins.Transform);
            gameObjectsNoRigidBody.ForEach(o => o.Draw(spriteBatch));
            gameObjectContainer.ForEachVisible(o => o.Draw(spriteBatch));
            spriteBatch.End();
        }

        private void HandleMouseButtonDown(Point pos)
        {
            var point = new Rectangle(Camera.Ins.ScreenToWorld(pos), Point.Zero);
            objectsFound.Clear();
            objectSelected = null;
            gameObjectContainer.Find(point, objectsFound);
            foreach (var o in objectsFound)
                if (o.RigidBody.Bound.Intersects(point))
                {
                    objectSelected = o;
                    break;
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
