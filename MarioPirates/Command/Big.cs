namespace MarioPirates.Command
{
    public class Big : ICommand
    {
        private Mario mario;

        public Big(Mario mario)
        {
            this.mario = mario;
        }

        public void Execute()
        {
            mario.State.Big();
        }
    }
}
