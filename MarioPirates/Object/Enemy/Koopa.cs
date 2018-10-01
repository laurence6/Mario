using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal class Koopa : GameObject
    {
        public Koopa(int x, int y)
        {
            location.X = x;
            location.Y = y;
            size = new Point(60, 48);
            Sprite = SpriteFactory.CreateSprite("koopa");
            RigidBody.Mass = 0.1f;
        }
    }
}
