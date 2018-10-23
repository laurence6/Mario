using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal sealed class Camera
    {
        public static readonly Camera Ins = new Camera();

        private Camera()
        {
            LookAt(Vector2.Zero);
        }

        public Matrix Transform { get; private set; }

        public void LookAt(Vector2 location)
        {
            Transform = Matrix.CreateTranslation(new Vector3(-location.X + 400f, 0f, 0f));
        }
    }
}
