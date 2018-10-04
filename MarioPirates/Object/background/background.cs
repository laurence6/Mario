using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal class Background : GameObject
    {
        private const int bkgdWidth = 800, bkgdHeight = 480;

        public Background(int X, int Y)
        {
            location = new Vector2(X, Y);
            size = new Point(bkgdWidth, bkgdHeight);
            Sprite = SpriteFactory.Instance.CreateSprite("background");
            RigidBody = null;
        }
    }
}
