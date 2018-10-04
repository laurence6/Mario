namespace MarioPirates
{
    internal class BrokenBlock : Block
    {
        public BrokenBlock(int dstX, int dstY, string state) : base(dstX, dstY, state)
        {
            normalStateSprite = SpriteFactory.Instance.CreateSprite("brokenblock");
        }
    }
}
