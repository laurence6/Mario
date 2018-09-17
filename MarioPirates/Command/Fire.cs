namespace MarioPirates.Command
{
    public class Fire : ICommand
    {
        private Mario mario;

        public Fire(Mario mario)
        {
            this.mario = mario;
        }

        public void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}
