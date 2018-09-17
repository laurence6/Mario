namespace MarioPirates.Command
{
    public class Up : ICommand
    {
        private Mario mario;

        public Up(Mario mario)
        {
            this.mario = mario;
        }

        public void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}
