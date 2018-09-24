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
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private Dictionary<string, Texture2D> textures = new Dictionary<string, Texture2D> {
            { "brick5", null },
            { "brick1", null },
            { "brick2", null },
            { "brick3", null },
            { "brick4", null },
            { "coins", null },
            { "flower", null },
            { "smallmario", null },
            { "bigmario", null },
            { "firemario", null },
            { "deadmario", null },
            { "greenmushroom", null },
            { "redmushroom", null },
            { "goomba", null },
            { "pipeline", null },
            { "stars", null },
            { "turtles", null },
        };

        private List<ISprite> sprites = new List<ISprite>();
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
            sprites.ForEach(s => s.Update());
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
            sprites.ForEach(s => s.Draw(spriteBatch, textures));
            spriteBatch.End();
        }

        public void Reset()
        {
            sprites.Clear();
            controllers.Clear();

            var mario = new Mario(600, 200);
            sprites.Add(mario);

            var hiddenBlock = new Block(100, 0);
            hiddenBlock.State.SetHide(true);
            hiddenBlock.State.ChangeToBrick4();
            sprites.Add(hiddenBlock);


            var brick1 = new Block(100, 150);
            brick1.State.ChangeToBrick1();
            sprites.Add(brick1);

            var brick2 = new Block(100, 200);
            brick2.State.ChangeToBrick2();
            sprites.Add(brick2);

            var brick3 = new Block(100, 250);
            brick3.State.ChangeToBrick3();
            sprites.Add(brick3);

            var brick4 = new Block(100, 100);
            brick4.State.ChangeToBrick4();
            sprites.Add(brick4);

            var brick5 = new Block(100, 50);
            sprites.Add(brick5);

            var pipe = new Pipe(200, 200);
            sprites.Add(pipe);

            var flower = new Flower(300, 300);
            sprites.Add(flower);

            var coin = new Coin(200, 300);
            sprites.Add(coin);

            var star = new Star(100, 300);
            sprites.Add(star);

            var redMush = new RedMushroom(400, 100);
            sprites.Add(redMush);

            var greenMush = new GreenMushroom(300, 100);
            sprites.Add(greenMush);

            var goomba1 = new Goomba(0, 400);
            sprites.Add(goomba1);

            var koopa1 = new Koopa(0, 350, Direction.right);
            sprites.Add(koopa1);
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
            keyboardController.AddCommandMapping(new Command.QuestionBlockUsed(brick1), Keys.Z);
            keyboardController.AddCommandMapping(new Command.SetBlockHidden(brick5, true), Keys.X);
            keyboardController.AddCommandMapping(new Command.SetBlockHidden(hiddenBlock, false), Keys.C);
            controllers.Add(keyboardController);

            var gamePadController = new GamePadController();
            gamePadController.AddCommandMapping(new Command.Quit(this), Buttons.Start);
            controllers.Add(gamePadController);
        }
    }
}
