namespace MarioPirates
{
    internal class BrokenBlock : BlockState
    {
        public BrokenBlock(Block block) : base(block)
        {
            block.sprite = SpriteFactory.Instance.CreateSprite("brokenblock");
        }

        public override void ChangeToBrokenBlock()
        {
        }
    }

}
