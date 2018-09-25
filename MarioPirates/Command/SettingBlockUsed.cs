namespace MarioPirates.Command
{
    internal class SettingBlockUsed : ICommand
    {
        private Block block;

        public SettingBlockUsed(Block block)
        {
            this.block = block;
        }

        public void Execute()
        {
            block.State.ChangeToBrownBlock();
        }
    }
}
