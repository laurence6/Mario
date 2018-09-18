namespace MarioPirates.Commands
{
    public class Dead : ICommand
    {
        private Mario mario;

        public Dead(Mario mario)
        {
            this.mario = mario;
        }

        public void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}
