using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal class Pipe : GameObject
    {
        private const int pipeWidth = 32, pipeHeight = 32;
        public Pipe(int dstX, int dstY)
        {
            Location.X = dstX;
            Location.Y = dstY;
            Size = new Point(pipeWidth * 2, pipeHeight * 2);
            Sprite = SpriteFactory.CreateSprite("pipe");
        }
    }
}
