using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal sealed class Camera
    {
        public static readonly Camera Ins = new Camera();

        private Camera()
        {
            Reset();
        }

        public Matrix Transform { get; private set; }

        private float x = 0f;

        public void LookAt(Vector2 location)
        {
            x = x.Max(location.X - 400f);
            Transform = Matrix.CreateTranslation(new Vector3(-x, 0f, 0f));
        }

        public void Reset()
        {
            x = 0f;
        }
    }
}
