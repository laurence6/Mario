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
        private float offset;

        public void Reset()
        {
            model = new Model(Constants.DEFAULT_SCENE);
            offset = Constants.SCREEN_WIDTH / 2;

            EventManager.Ins.Subscribe(EventEnum.KeyLeftHold, () => { offset = (offset - Constants.MAPEDITOR_MOVING_SPEED).Max(0f); Camera.Ins.LookAt(offset, true); });
            EventManager.Ins.Subscribe(EventEnum.KeyRightHold, () => { offset = (offset + Constants.MAPEDITOR_MOVING_SPEED).Max(0f); Camera.Ins.LookAt(offset, true); });
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
