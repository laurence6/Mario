namespace MarioPirates.Commands
{
    public class Left : ICommand
    {
        private Mario mario;

        public Left(Mario mario)
        {
            this.mario = mario;
        }

        public void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}
