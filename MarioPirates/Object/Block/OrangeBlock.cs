namespace MarioPirates
{
    internal class OrangeBlock : Block
    {
        public OrangeBlock(int dstX, int dstY) : base(dstX, dstY)
        {
            Sprite = SpriteFactory.CreateSprite("orangeblock");
        }
    }
}
