namespace MarioPirates
{
    internal class OrangeBlock : BlockState
    {
        public OrangeBlock(Block block) : base(block)
        {
            block.Sprite = SpriteFactory.CreateSprite("orangeblock");
        }

        public override void ChangeToOrangeBlock()
        {
        }
    }
}
