using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal class Goomba : GameObject
    {
        public Goomba(int x, int y)
        {
            location.X = x;
            location.Y = y;
            size = new Point(60, 40);
            Sprite = SpriteFactory.CreateSprite("goomba");
            RigidBody.Mass = 0.1f;
        }
    }
}
