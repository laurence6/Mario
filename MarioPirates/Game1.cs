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

        private List<ISprite> sprites = new List<ISprite>();
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
            Mario mario = new Mario();
            sprites.Add(mario);

            var keyboardController = new KeyboardController();
            keyboardController.AddCommandMapping(new Commands.Quit(this), Keys.Q);
            keyboardController.AddCommandMapping(new Commands.Up(mario), Keys.Up, Keys.W);
            keyboardController.AddCommandMapping(new Commands.Down(mario), Keys.Down, Keys.S);
            keyboardController.AddCommandMapping(new Commands.Left(mario), Keys.Left, Keys.A);
            keyboardController.AddCommandMapping(new Commands.Right(mario), Keys.Right, Keys.D);
            keyboardController.AddCommandMapping(new Commands.Small(mario), Keys.Y);
            keyboardController.AddCommandMapping(new Commands.Big(mario), Keys.U);
            keyboardController.AddCommandMapping(new Commands.Fire(mario), Keys.I);
            keyboardController.AddCommandMapping(new Commands.Dead(mario), Keys.O);
            controllers.Add(keyboardController);

            var gamePadController = new GamePadController();
            gamePadController.AddCommandMapping(new Commands.Quit(this), Buttons.Start);
            controllers.Add(gamePadController);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
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
            sprites.ForEach(s => s.Update());
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            sprites.ForEach(s => s.Draw(spriteBatch, texture));
            spriteBatch.End();
        }
    }
}