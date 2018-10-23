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

        private float x;

        public void LookAt(Vector2 location)
        {
            x = x.Max(location.X - 400f);
            Transform = Matrix.CreateTranslation(new Vector3(-x, 0f, 0f));
        }
    }
}
