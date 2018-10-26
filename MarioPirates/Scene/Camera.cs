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

        public Matrix Transform { get; private set; }

        public Rectangle VisiableArea { get; private set; }

        public GameObjectRigidBody[] VirtualWalls { get; } = new GameObjectRigidBody[] { new VirtualPlane(0, 0), new VirtualWall(0, 0), new VirtualWall(0, 0) };

        private float x = 0f;

        public void Reset()
        {
            x = 0;
            LookAt(Vector2.Zero);
        }

        public void LookAt(Vector2 location)
        {
            x = x.Max(location.X - 400f);
            Transform = Matrix.CreateTranslation(new Vector3(-x, 0f, 0f));
            VisiableArea = new Rectangle((int)x, 0, ScreenWidth, ScreenHeight);
            VirtualWalls[0].Location = new Vector2(x, ScreenHeight + 1);
            VirtualWalls[1].Location = new Vector2(VisiableArea.Left - 1f, 0f);
            VirtualWalls[2].Location = new Vector2(VisiableArea.Right - 1f, 0f);
        }
    }
}
