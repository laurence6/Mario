namespace MarioPirates.Command
{
    internal class Right : ICommand
    {
        private Mario mario;

        public Right(Mario mario)
        {
            this.mario = mario;
        }

        public void Execute()
        {
            mario.State.Right();
        }
    }
}
