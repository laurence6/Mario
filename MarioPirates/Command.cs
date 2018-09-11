namespace MarioPirates
{
    interface ICommand
    {
        void Execute();
    }

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

    class SpriteSettingCommand<T> : ICommand where T : ISprite, new()
    {
        private Game1 game;
        private ISprite sprite;

        public SpriteSettingCommand(Game1 game)
        {
            this.game = game;
            this.sprite = new T();
        }

        public void Execute()
        {
            game.Sprite = sprite;
        }
    }
}