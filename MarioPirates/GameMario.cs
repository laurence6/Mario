using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;

namespace MarioPirates
{
    using Controller;
    using Event;

    internal class GameMario : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private Dictionary<string, Texture2D> textures = new Dictionary<string, Texture2D> {
            { "bigmario", null },
            { "bigstarpowermario", null },
            { "brickblock", null },
            { "brokenblock", null },
            { "brownblock", null },
            { "coins", null },
            { "deadmario", null },
            { "firemario", null },
            { "flower", null },
            { "goomba", null },
            { "greenmushroom", null },
            { "koopa", null },
            { "orangeblock", null },
            { "pipeline", null },
            { "questionblock", null },
            { "redmushroom", null },
            { "smallmario", null },
            { "smallstarpowermario", null },
            { "stars", null },
            { "frame", null },
        };

        private List<IController> controllers = new List<IController>();

        public GameMario()
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
            Reset();
            graphics.IsFullScreen = false;
            base.Initialize();
        }

        private bool triggerReset = false;

        public void TriggerReset() => triggerReset = true;

        private void Reset()
        {
            EventManager.Instance.Reset();
            Physics.Reset();
            Scene.Instance.Reset();

            EventManager.Instance.Subscribe(e =>
            {
                switch ((e as KeyDownEvent).Key)
                {
                    case Keys.Q:
                        Exit();
                        break;
                    case Keys.R:
                        TriggerReset();
                        break;
                }
            }, EventEnum.KeyDown);

            controllers.Clear();
            triggerReset = false;

            var keyboardController = new KeyboardController();
            keyboardController.SetKeyMapping(Keys.W, Keys.Up);
            keyboardController.SetKeyMapping(Keys.S, Keys.Down);
            keyboardController.SetKeyMapping(Keys.A, Keys.Left);
            keyboardController.SetKeyMapping(Keys.D, Keys.Right);
            keyboardController.EnableKeyEvent(InputState.Down, Keys.Q, Keys.R);
            keyboardController.EnableKeyEvent(InputState.Down, Keys.Up, Keys.Down, Keys.Left, Keys.Right);
            keyboardController.EnableKeyEvent(InputState.Up, Keys.Up, Keys.Down, Keys.Left, Keys.Right);
            keyboardController.EnableKeyEvent(InputState.Hold, Keys.Up, Keys.Down, Keys.Left, Keys.Right);
            keyboardController.EnableKeyEvent(InputState.Down, Keys.Y, Keys.U, Keys.I, Keys.O, Keys.P);
            controllers.Add(keyboardController);

            var gamePadController = new GamePadController();
            controllers.Add(gamePadController);
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            textures.Keys.ToList().ForEach(name => textures[name] = Content.Load<Texture2D>(name));
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
            Scene.Instance.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
            EventManager.Instance.ProcessQueue();

            if (triggerReset)
                Reset();
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            Scene.Instance.Draw(spriteBatch, textures);
        }
    }
}
