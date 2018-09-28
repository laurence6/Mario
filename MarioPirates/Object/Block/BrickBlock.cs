namespace MarioPirates
{
    internal class BrickBlock : BlockState
    {
        public BrickBlock(Block block) : base(block)
        {
            block.Sprite = SpriteFactory.CreateSprite("brickblock");
        }

        public override void ChangeToBrickBlock()
        {
        }
    }
}
