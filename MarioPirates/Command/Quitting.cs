namespace MarioPirates.Command
{
    internal class Quitting : ICommand
    {
        private Game1 game;

        public Quitting(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.Exit();
        }
    }
}
