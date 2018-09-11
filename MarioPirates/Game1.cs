using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace MarioPirates
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public ISprite Sprite { get; set; }

        private List<IController> controllers = new List<IController>();
        private Texture2D texture;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // Initialize commands.
            var spriteSettingCommandMarioSpriteW = new SpriteSettingCommand<MarioSpriteW>(this);
            var spriteSettingCommandMarioSpriteE = new SpriteSettingCommand<MarioSpriteE>(this);
            var spriteSettingCommandMarioSpriteR = new SpriteSettingCommand<MarioSpriteR>(this);
            var spriteSettingCommandMarioSpriteT = new SpriteSettingCommand<MarioSpriteT>(this);

            // Initialize controllers.
            var keyboardController = new KeyboardController();
            keyboardController.AddCommandMapping(Keys.Q, new QuittingCommand(this));
            keyboardController.AddCommandMapping(Keys.W, spriteSettingCommandMarioSpriteW);
            keyboardController.AddCommandMapping(Keys.E, spriteSettingCommandMarioSpriteE);
            keyboardController.AddCommandMapping(Keys.R, spriteSettingCommandMarioSpriteR);
            keyboardController.AddCommandMapping(Keys.T, spriteSettingCommandMarioSpriteT);
            controllers.Add(keyboardController);

            var gamePadController = new GamePadController();
            gamePadController.AddCommandMapping(Buttons.Start, new QuittingCommand(this));
            gamePadController.AddCommandMapping(Buttons.A, spriteSettingCommandMarioSpriteW);
            gamePadController.AddCommandMapping(Buttons.B, spriteSettingCommandMarioSpriteE);
            gamePadController.AddCommandMapping(Buttons.X, spriteSettingCommandMarioSpriteR);
            gamePadController.AddCommandMapping(Buttons.Y, spriteSettingCommandMarioSpriteT);
            controllers.Add(gamePadController);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            texture = Content.Load<Texture2D>("mario");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            Content.Unload();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            controllers.ForEach(c => c.Update());
            Sprite?.Update();

            // base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            Sprite?.Draw(spriteBatch, texture);
            spriteBatch.End();

            // base.Draw(gameTime);
        }
    }
}