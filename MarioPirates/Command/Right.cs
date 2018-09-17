namespace MarioPirates.Command
{
    public class Right : ICommand
    {
        private Mario mario;

        public Right(Mario mario)
        {
            this.mario = mario;
        }

        public void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}
