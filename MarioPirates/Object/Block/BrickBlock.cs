namespace MarioPirates
{
    internal class BrickBlock : BlockState
    {
        public BrickBlock(Block block) : base(block)
        {
            block.sprite = SpriteFactory.Instance.CreateSprite("brickblock");
        }

        public override void ChangeToBrickBlock()
        {
        }
    }
}
