using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal class Star : GameObject
    {
        private const int starWidth = 30, starHeight = 24;
        public Star(int dstX, int dstY)
        {
            Location.X = dstX;
            Location.Y = dstY;
            Size = new Point(starWidth * 2, starHeight * 2);
            Sprite = SpriteFactory.Instance.CreateSprite("stars");
        }
    }
}
