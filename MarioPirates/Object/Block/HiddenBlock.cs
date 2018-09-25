namespace MarioPirates
{
    internal class HiddenBlock : BlockState
    {
        public HiddenBlock(Block block) : base(block)
        {
            block.Sprite = null;
        }

        public override void ChangeToHiddenBlock()
        {
        }
    }
}
