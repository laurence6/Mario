namespace MarioPirates
{
    internal class BrickBlock : Block
    {
        public BrickBlock(int dstX, int dstY) : base(dstX, dstY)
        {
            Sprite = SpriteFactory.Instance.CreateSprite("brickblock");
        }
    }
}
