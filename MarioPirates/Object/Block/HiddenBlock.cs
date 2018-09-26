namespace MarioPirates
{
    class HiddenBlock : BlockState
    {
        public HiddenBlock(Block block) : base(block)
        {
            block.sprite = SpriteFactory.Instance.CreateSprite(null);
        }
    }
}
