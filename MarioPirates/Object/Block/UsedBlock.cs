namespace MarioPirates
{
    internal class UsedBlock : Block
    {
        public UsedBlock(int dstX, int dstY, string state)
            : base(dstX, dstY, state, SpriteFactory.Instance.CreateSprite("brownblock"))
        {
        }
    }
}
