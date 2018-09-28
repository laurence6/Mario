namespace MarioPirates
{
    internal class BrownBlock : BlockState
    {
        public BrownBlock(Block block) : base(block)
        {
            block.Sprite = SpriteFactory.CreateSprite("brownblock");
        }

        public override void ChangeToBrownBlock()
        {
        }
    }
}
