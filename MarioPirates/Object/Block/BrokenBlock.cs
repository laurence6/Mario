namespace MarioPirates
{
    internal class BrokenBlock : BlockState
    {
        public BrokenBlock(Block block) : base(block)
        {
            block.Sprite = SpriteFactory.CreateSprite("brokenblock");
        }

        public override void ChangeToBrokenBlock()
        {
        }
    }
}
