using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal sealed class Camera
    {
        public static readonly Camera Ins = new Camera();

        private Camera()
        {
        }

        public Vector2 Offset { get; private set; } = Vector2.Zero;

        public Matrix Transform { get; private set; }

        public Rectangle VisibleArea { get; private set; }

        public void Reset()
        {
            Offset = Vector2.Zero;
            LookAt(Vector2.Zero);
        }

        public void LookAt(Vector2 location, bool backward = false)
        {
            LookAt(location.X, backward);
        }

        public void LookAt(float x, bool backward = false)
        {
            x = (x - Constants.SCREEN_WIDTH / 2).Max(backward ? 0f : Offset.X);
            Offset = new Vector2(x, 0f);
            Transform = Matrix.CreateTranslation(new Vector3(-Offset, 0f));
            VisibleArea = new Rectangle((int)Offset.X, (int)Offset.Y, Constants.SCREEN_WIDTH, Constants.SCREEN_HEIGHT);
        }
    }
}
