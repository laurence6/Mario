namespace MarioPirates.Command
{
    public class SettingBlockUsed : ICommand
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
