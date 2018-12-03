using Microsoft.Xna.Framework.Graphics;

namespace MarioPirates
{
    internal sealed class Scene
    {
        public static readonly Scene Ins = new Scene();

        private Scene()
        {
        }

        private Model model;

        public void Reset()
        {
            model = new Model(Constants.DEFAULT_SCENE);

            EventManager.Ins.Subscribe(EventEnum.KeyLeftHold, () => { Camera.Ins.Offset -= Constants.MAPEDITOR_MOVING_SPEED; Camera.Ins.Update(); });
            EventManager.Ins.Subscribe(EventEnum.KeyRightHold, () => { Camera.Ins.Offset += Constants.MAPEDITOR_MOVING_SPEED; Camera.Ins.Update(); });
        }

        public void Update(float dt)
        {
            model.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            model.Draw(spriteBatch);
        }
    }
}
