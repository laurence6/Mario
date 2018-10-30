using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal sealed class Camera
    {
        public static readonly Camera Ins = new Camera();

        public const int ScreenWidth = 800, ScreenHeight = 480;

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

        public void LookAt(Vector2 location)
        {
            Offset = new Vector2(Offset.X.Max(location.X - ScreenWidth / 2), 0f);
            Transform = Matrix.CreateTranslation(new Vector3(-Offset, 0f));
            VisibleArea = new Rectangle((int)Offset.X, (int)Offset.Y, ScreenWidth, ScreenHeight);
        }
    }
}
