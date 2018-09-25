namespace MarioPirates.Command
{
    internal class SettingBlockHidden : ICommand
    {
        private Block block;

        public SettingBlockHidden(Block block)
        {
            this.block = block;
        }

        public void Execute()
        {
            block.State.ChangeToHiddenBlock();
        }
    }
}
