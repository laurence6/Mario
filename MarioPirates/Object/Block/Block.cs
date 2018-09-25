using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal class Block : GameObject
    {
        public BlockState State { get; set; }

        private const int blockWidth = 16, blockHeight = 16;

        public Block(int dstX, int dstY)
        {
            Location.X = dstX;
            Location.Y = dstY;
            Size = new Point(blockWidth * 2, blockHeight * 2);

            State = new OrangeBlock(this);
        }
    }

}

