namespace MarioPirates.Command
{
    internal class Fire : ICommand
    {
        private Mario mario;

        public Fire(Mario mario)
        {
            this.mario = mario;
        }

        public void Execute()
        {
            mario.State.Fire();
        }
    }
}
