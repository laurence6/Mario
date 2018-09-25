namespace MarioPirates.Command
{
    internal class Small : ICommand
    {
        private Mario mario;

        public Small(Mario mario)
        {
            this.mario = mario;
        }

        public void Execute()
        {
            mario.State.Small();
        }
    }
}
