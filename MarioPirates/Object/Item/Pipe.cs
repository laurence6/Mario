using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal class Pipe : GameObjectRigidBody
    {
        private const int pipeWidth = 32, pipeHeight = 32;
        public Pipe(int dstX, int dstY)
        {
            location.X = dstX;
            location.Y = dstY;
            size = new Point(pipeWidth * 2, pipeHeight * 2);
            Sprite = SpriteFactory.Instance.CreateSprite("pipe");
        }
    }
}
