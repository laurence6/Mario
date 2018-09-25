using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;

namespace MarioPirates
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
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
            { "orangeblock", null },
            { "pipeline", null },
            { "questionblock", null },
            { "redmushroom", null },
            { "smallmario", null },
            { "stars", null },
            { "turtles", null },
        };

        private List<GameObject> gameObjects = new List<GameObject>();
        private List<IController> controllers = new List<IController>();

        public bool TriggerReset = false;

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
            if (TriggerReset)
            {
                Reset();
                TriggerReset = false;
            }
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

        public void Reset()
        {
            gameObjects.Clear();
            controllers.Clear();

            var mario = new Mario(600, 200);
            gameObjects.Add(mario);

            var hiddenBlock = new Block(100, 0);
            hiddenBlock.State.ChangeToHiddenBlock();
            gameObjects.Add(hiddenBlock);

            var block1 = new Block(100, 150);
            block1.State.ChangeToBrickBlock();
            gameObjects.Add(block1);

            var block2 = new Block(100, 200);
            block2.State.ChangeToBrokenBlock();
            gameObjects.Add(block2);

            var block3 = new Block(100, 250);
            block3.State.ChangeToBrownBlock();
            gameObjects.Add(block3);

            var block4 = new Block(100, 100);
            block4.State.ChangeToOrangeBlock();
            gameObjects.Add(block4);

            var block5 = new Block(100, 50);
            block5.State.ChangeToQuestionBlock();
            gameObjects.Add(block5);

            var pipe = new Pipe(200, 200);
            gameObjects.Add(pipe);

            var flower = new Flower(300, 300);
            gameObjects.Add(flower);

            var coin = new Coin(200, 300);
            gameObjects.Add(coin);

            var star = new Star(100, 300);
            gameObjects.Add(star);

            var redMush = new RedMushroom(400, 100);
            gameObjects.Add(redMush);

            var greenMush = new GreenMushroom(300, 100);
            gameObjects.Add(greenMush);

            var goomba1 = new Goomba(0, 400);
            gameObjects.Add(goomba1);

            var keyboardController = new KeyboardController();
            keyboardController.AddCommandMapping(new Command.Quit(this), Keys.Q);
            keyboardController.AddCommandMapping(new Command.Reset(this), Keys.R);
            keyboardController.AddCommandMapping(new Command.Up(mario), Keys.Up, Keys.W);
            keyboardController.AddCommandMapping(new Command.Down(mario), Keys.Down, Keys.S);
            keyboardController.AddCommandMapping(new Command.Left(mario), Keys.Left, Keys.A);
            keyboardController.AddCommandMapping(new Command.Right(mario), Keys.Right, Keys.D);
            keyboardController.AddCommandMapping(new Command.Small(mario), Keys.Y);
            keyboardController.AddCommandMapping(new Command.Big(mario), Keys.U);
            keyboardController.AddCommandMapping(new Command.Fire(mario), Keys.I);
            keyboardController.AddCommandMapping(new Command.Dead(mario), Keys.O);
            keyboardController.AddCommandMapping(new Command.SettingBlockUsed(block1), Keys.Z);
            keyboardController.AddCommandMapping(new Command.SettingBlockHidden(block5), Keys.X);
            keyboardController.AddCommandMapping(new Command.SettingBlockUsed(hiddenBlock), Keys.C);
            controllers.Add(keyboardController);

            var gamePadController = new GamePadController();
            gamePadController.AddCommandMapping(new Command.Quit(this), Buttons.Start);
            controllers.Add(gamePadController);
        }
    }
}
