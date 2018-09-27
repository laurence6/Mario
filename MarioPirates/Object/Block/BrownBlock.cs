namespace MarioPirates
{
    internal class BrownBlock : BlockState
    {
        public BrownBlock(Block block) : base(block)
        {
            block.Sprite = SpriteFactory.Instance.CreateSprite("brownblock");
        }

        public override void ChangeToBrownBlock()
        {
        }
    }
}
