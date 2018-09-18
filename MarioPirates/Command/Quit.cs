namespace MarioPirates.Commands
{
    class Quit : ICommand
    {
        private Game1 game;

        public Quit(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.Exit();
        }
    }
}
