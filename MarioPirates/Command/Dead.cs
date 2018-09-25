namespace MarioPirates.Command
{
    internal class Dead : ICommand
    {
        private Mario mario;

        public Dead(Mario mario)
        {
            this.mario = mario;
        }

        public void Execute()
        {
            mario.State.Dead();
        }
    }
}
