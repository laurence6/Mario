namespace MarioPirates
{
    internal class OrangeBlock : Block
    {
        public OrangeBlock(int dstX, int dstY, string state)
            : base(dstX, dstY, state, SpriteFactory.Ins.CreateSprite("orangeblock"))
        {
        }
    }
}
