using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MarioPirates
{
    internal sealed class Scene
    {
        public static readonly Scene Ins = new Scene();

        private Scene()
        {
        }

        public Model Model { get; private set; }

        public void Reset()
        {
            Model = new Model(Constants.DEFAULT_SCENE);

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
        }

        public void Update(float dt)
        {
            Model.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Model.Draw(spriteBatch);
        }
    }
}
