using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal class Koopa : GameObject
    {
        private const int koopaWidth = 16, koopaHeight = 16;
        public Koopa(int x, int y)
        {
            location.X = x;
            location.Y = y;
            size = new Point(koopaWidth * 2, koopaHeight * 2);
            Sprite = SpriteFactory.Instance.CreateSprite("koopa");
            RigidBody.Mass = 0.1f;
        }
    }
}
