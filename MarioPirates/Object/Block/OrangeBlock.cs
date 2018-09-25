namespace MarioPirates
{
    internal class OrangeBlock : BlockState
    {
        public OrangeBlock(Block block) : base(block)
        {
            block.sprite = SpriteFactory.Instance.CreateSprite("orangeblock");
        }

        public override void ChangeToOrangeBlock()
        {
        }
    }

}
