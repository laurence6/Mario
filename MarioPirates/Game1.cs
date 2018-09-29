using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;

namespace MarioPirates
{
    using Controller;
    using Event;

    internal class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private Dictionary<string, Texture2D> textures = new Dictionary<string, Texture2D> {
            { "bigmario", null },
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
            { "leftcrouchbigmario", null },
            { "leftcrouchfiremario", null },
            { "orangeblock", null },
            { "pipeline", null },
            { "questionblock", null },
            { "redmushroom", null },
            { "rightcrouchbigmario", null },
            { "rightcrouchfiremario", null },
            { "smallmario", null },
            { "stars", null },
        };

        private List<GameObject> gameObjects = new List<GameObject>();
        private List<IController> controllers = new List<IController>();

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
            Reset();

            base.Initialize();
        }

        private bool triggerReset = false;

        public void TriggerReset() => triggerReset = true;

        private void Reset()
        {
            EventManager.Instance.Reset();

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

            gameObjects.Clear();
            controllers.Clear();
            triggerReset = false;

            var mario = new Mario(600, 200);
            gameObjects.Add(mario);

            var hiddenBlock = new Block(100, 0);
            hiddenBlock.State.ChangeToHiddenBlock();
            gameObjects.Add(hiddenBlock);

            var brickBlock = new Block(100, 150);
            brickBlock.State.ChangeToBrickBlock();
            gameObjects.Add(brickBlock);

            var brokenBlock = new Block(100, 200);
            brokenBlock.State.ChangeToBrokenBlock();
            gameObjects.Add(brokenBlock);

            var brownBlock = new Block(100, 250);
            brownBlock.State.ChangeToBrownBlock();
            gameObjects.Add(brownBlock);

            var orangeBlock = new Block(100, 100);
            orangeBlock.State.ChangeToOrangeBlock();
            gameObjects.Add(orangeBlock);

            var questionBlock = new Block(100, 50);
            questionBlock.State.ChangeToQuestionBlock();
            gameObjects.Add(questionBlock);

            var pipe = new Pipe(200, 200);
            gameObjects.Add(pipe);

            var flower = new Flower(400, 100);
            gameObjects.Add(flower);

            var coin = new Coin(600, 100);
            gameObjects.Add(coin);

            var star = new Star(500, 100);
            gameObjects.Add(star);

            var redMush = new RedMushroom(200, 100);
            gameObjects.Add(redMush);

            var greenMush = new GreenMushroom(300, 100);
            gameObjects.Add(greenMush);

            var koopa = new Koopa(700, 100);
            gameObjects.Add(koopa);

            var goomba = new Goomba(0, 400);
            gameObjects.Add(goomba);

            var keyboardController = new KeyboardController();
            keyboardController.EnableKeyEvent(InputState.Down, Keys.Q, Keys.R);
            keyboardController.EnableKeyEvent(InputState.Down, Keys.Up, Keys.W, Keys.Down, Keys.S, Keys.Left, Keys.A, Keys.Right, Keys.D);
            keyboardController.EnableKeyEvent(InputState.Up, Keys.Up, Keys.W, Keys.Down, Keys.S, Keys.Left, Keys.A, Keys.Right, Keys.D);
            keyboardController.EnableKeyEvent(InputState.Down, Keys.U, Keys.I);
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
            gameObjects.ForEach(o => o.Update());
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

            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            gameObjects.ForEach(o => o.Draw(spriteBatch, textures));
            spriteBatch.End();
        }
    }
}
