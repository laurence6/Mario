namespace MarioPirates
{
    class QuittingCommand : ICommand
    {
        private Game1 game;

        public QuittingCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.Exit();
        }
    }
}
