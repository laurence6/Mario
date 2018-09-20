namespace MarioPirates.Command
{
    class Reset : ICommand
    {
        private Game1 game;

        public Reset(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.TriggerReset = true;
        }
    }
}
