namespace MarioPirates
{
    internal class BrownBlock : BlockState
    {
        public BrownBlock(Block block) : base(block)
        {
            block.sprite = SpriteFactory.Instance.CreateSprite("brownblock");
        }

        public override void ChangeToBrownBlock()
        {
        }
    }

}
