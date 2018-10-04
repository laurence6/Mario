namespace MarioPirates
{
    internal class BrickBlock : Block
    {
        public BrickBlock(int dstX, int dstY, string state) : base(dstX, dstY, state)
        {
            normalStateSprite = SpriteFactory.Instance.CreateSprite("brickblock");
        }
    }
}
