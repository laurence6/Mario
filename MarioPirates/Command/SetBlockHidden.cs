namespace MarioPirates.Command
{
    public class SetBlockHidden : ICommand
    {
        private Block block;
        private bool hidden;

        public SetBlockHidden(Block block, bool hidden)
        {
            this.block = block;
            this.hidden = hidden;
        }

        public void Execute()
        {
            block.State.SetHide(hidden);
        }
    }
}
