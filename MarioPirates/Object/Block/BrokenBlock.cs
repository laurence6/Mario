namespace MarioPirates
{
    internal class BrokenBlock : Block
    {
        public BrokenBlock(int dstX, int dstY, string state)
            : base(dstX, dstY, state, SpriteFactory.CreateSprite("brokenblock"))
        {
        }
    }
}
