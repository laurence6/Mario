using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal class Goomba : GameObject
    {
        private int vx = 1;

        public Goomba(int x, int y)
        {
            Location.X = x;
            Location.Y = y;
            Size = new Point(60, 40);
            Sprite = SpriteFactory.Instance.CreateSprite("goomba");
        }

        public override void Update()
        {
            vx = (Location.X == 0) ? 1 : (Location.X == 800 - 48) ? -1 : vx;
            Location.X += vx;
            base.Update();
        }
    }
}
