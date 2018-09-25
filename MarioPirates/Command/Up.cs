namespace MarioPirates.Command
{
    internal class Up : ICommand
    {
        private Mario mario;

        public Up(Mario mario)
        {
            this.mario = mario;
        }

        public void Execute()
        {
            mario.State.Jump();
        }
    }
}
