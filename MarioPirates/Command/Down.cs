namespace MarioPirates.Command
{
    public class Down : ICommand
    {
        private Mario mario;

        public Down(Mario mario)
        {
            this.mario = mario;
        }

        public void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}
