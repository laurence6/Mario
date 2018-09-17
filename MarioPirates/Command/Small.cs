namespace MarioPirates.Command
{
    public class Small : ICommand
    {
        private Mario mario;

        public Small(Mario mario)
        {
            this.mario = mario;
        }

        public void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}
