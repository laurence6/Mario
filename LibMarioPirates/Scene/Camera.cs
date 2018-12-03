using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal sealed class Camera
    {
        public static readonly Camera Ins = new Camera();

        private Camera()
        {
        }

        private float offset = 0f;
        public float Offset { get => offset; set { offset = value.Max(0f); } }

        public Matrix Transform { get; private set; }

        public Rectangle VisibleArea { get; private set; }

        public void Reset()
        {
            offset = 0f;
            Update();
        }

        public void LookAt(float x, bool backward = false)
        {
            x -= Constants.SCREEN_WIDTH / 2;
            if (!backward)
                x = x.Max(Offset);
            Offset = x;
            Update();
        }

        public void LookAt(Vector2 location, bool backward = false) => LookAt(location.X, backward);

        public void Update()
        {
            Transform = Matrix.CreateTranslation(new Vector3(-Offset, 0f, 0f));
            VisibleArea = new Rectangle((int)Offset, 0, Constants.SCREEN_WIDTH, Constants.SCREEN_HEIGHT);
        }
    }
}
