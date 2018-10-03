namespace MarioPirates
{
    internal class BrokenBlock : Block
    {
        public BrokenBlock(int dstX, int dstY) : base(dstX, dstY)
        {
            Sprite = SpriteFactory.Instance.CreateSprite("brokenblock");
        }
    }
}
