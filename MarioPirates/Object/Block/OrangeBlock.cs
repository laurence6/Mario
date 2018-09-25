namespace MarioPirates
{
    internal class OrangeBlock : BlockState
    {
        public OrangeBlock(Block block) : base(block)
        {
            block.Sprite = SpriteFactory.Instance.CreateSprite("orangeblock");
        }

        public override void ChangeToOrangeBlock()
        {
        }
    }

}
