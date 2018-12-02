using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MarioPirates
{
    using Controller;

    internal class MapEditor : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        public List<IController> Controllers { get; } = new List<IController>();

        public MapEditor()
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
        }

        protected override void UnloadContent()
        {
            Content.Unload();
        }

        protected override void Update(GameTime gameTime)
        {
        }

        protected override void Draw(GameTime gameTime)
        {
        }
    }
}
