using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal class Pipe : GameObject
    {
        private const int pipeWidth = 64, pipeHeight = 46;
        public Pipe(int dstX, int dstY)
        {
            Location.X = dstX;
            Location.Y = dstY;
            Size = new Point(pipeWidth * 2, pipeHeight * 2);
            Sprite = SpriteFactory.Instance.CreateSprite("pipe");
        }
    }
}
