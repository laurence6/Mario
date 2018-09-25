namespace MarioPirates.Command
{
    internal class Resetting : ICommand
    {
        private Game1 game;

        public Resetting(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.TriggerReset = true;
        }
    }
}
