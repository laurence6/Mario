namespace MarioPirates
{
    internal class UsedBlock : Block
    {
        public UsedBlock(int dstX, int dstY) : base(dstX, dstY)
        {
            Sprite = SpriteFactory.Instance.CreateSprite("brownblock");
        }
    }
}
