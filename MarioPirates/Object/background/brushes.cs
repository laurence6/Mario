using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal class Brushes : GameObject
    {
       
        private const int brushesWidth = 100, brushesHeight = 17;
        public Brushes(int dstX, int dstY)
        {
            location.X = dstX;
            location.Y = dstY;
            size = new Point(brushesWidth, brushesHeight);
            Sprite = SpriteFactory.CreateSprite("brushes");
        }

        
    }
}
