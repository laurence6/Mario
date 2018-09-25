using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal class Koopa : GameObject
    {
        public Koopa(int x, int y)
        {
            Location.X = x;
            Location.Y = y;
            Size = new Point(60, 48);
            Sprite = SpriteFactory.Instance.CreateSprite("koopa");
        }
    }
}
