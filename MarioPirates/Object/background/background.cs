using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal class Background : GameObject
    {
        private const int bkgdWidth = 800, bkgdHeight = 480;

        public Background()
        {
            location = Vector2.Zero;
            size = new Point(bkgdWidth, bkgdHeight);
            Sprite = SpriteFactory.Instance.CreateSprite("background");
            RigidBody = null;
        }
    }
}
