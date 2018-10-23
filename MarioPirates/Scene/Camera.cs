using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal class Camera
    {
        public Matrix Transform { get; private set; }

        public Camera() : this(Vector2.Zero)
        {
        }

        public Camera(Vector2 location)
        {
            LookAt(location);
        }

        public void LookAt(Vector2 location)
        {
            Transform = Matrix.CreateTranslation(new Vector3(-location, 0f));
        }
    }
}
