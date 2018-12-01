using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MarioPirates
{
    using Controller;

    internal class GameMario : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        public List<IController> Controllers { get; } = new List<IController>();

        public GameMarioState State { get; set; }

        public GameMario()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = Constants.CONTENT_ROOT;
        }

        protected override void Initialize()
        {
            base.Initialize();

            graphics.IsFullScreen = false;

            spriteBatch = new SpriteBatch(GraphicsDevice);
            SpriteFactory.Ins.LoadContent(Content);
            AudioManager.Ins.LoadContent(Content);

            GameMarioStatePendingHandler.GameOverReset(this);
        }

        protected override void LoadContent()
        {
        }

        protected override void UnloadContent()
        {
            Content.Unload();
        }

        protected override void Update(GameTime gameTime)
        {
            State.DoUpdate(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            State.DoDraw(spriteBatch);
        }
    }
}
