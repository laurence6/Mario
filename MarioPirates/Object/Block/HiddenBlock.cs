namespace MarioPirates
{
    class HiddenBlock : BlockState
    {
        public HiddenBlock(Block block) : base(block)
        {
            block.sprite = null;
        }

        public override void ChangeToHiddenBlock()
        {
        }
    }
}
