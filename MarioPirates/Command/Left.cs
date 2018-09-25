namespace MarioPirates.Command
{
    internal class Left : ICommand
    {
        private Mario mario;

        public Left(Mario mario)
        {
            this.mario = mario;
        }

        public void Execute()
        {
            mario.State.Left();
        }
    }
}
