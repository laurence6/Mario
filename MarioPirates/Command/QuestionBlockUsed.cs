namespace MarioPirates.Command
{
    public class QuestionBlockUsed : ICommand
    {
        private Block block;

        public QuestionBlockUsed(Block block)
        {
            this.block = block;
        }

        public void Execute()
        {
            block.state.ChangeToBrick4();
        }
    }
}
