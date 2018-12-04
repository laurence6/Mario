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

        private HashSet<GameObjectRigidBody> objectsFound = new HashSet<GameObjectRigidBody>();
        private IGameObject objectSelected = null;
        private Vector2 objectSelectedOffset = Vector2.Zero;

        public void Reset()
        {
            Model = new Model(Constants.DEFAULT_SCENE);
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

        public void Update(float dt)
        {
            Model.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Model.Draw(spriteBatch);
        }

        private void HandleMouseButtonDown(Point pos)
        {
            var point = new Rectangle(Camera.Ins.ScreenToWorld(pos), Point.Zero);
            objectsFound.Clear();
            objectSelected = null;
            Model.gameObjectContainer.Find(point, objectsFound);
            foreach (var o in objectsFound)
                if (o.RigidBody.Bound.Intersects(point))
                {
                    objectSelected = o;
                    break;
                }
        }

        private void HandleMouseButtonUp(Point pos)
        {
            objectSelected = null;
        }

        private void HandleMouseButtonHold(Point pos)
        {
            if (objectSelected != null)
                objectSelected.Location = Align(Camera.Ins.ScreenToWorld(pos)).ToVector2();
        }

        private Point Align(Point pos)
        {
            pos.X &= ~0b1111;
            pos.Y &= ~0b1111;
            return pos;
        }
    }
}
