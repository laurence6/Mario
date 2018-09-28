using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;

namespace MarioPirates
{
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
            { "koopa", null },
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
            EventManager.Instance.Subscribe(EventEnum.Quit, e => Exit());
            EventManager.Instance.Subscribe(EventEnum.Reset, e => Reset());

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
            EventManager.Instance.ProcessQueue();
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
            EventManager.Instance.Subscribe(EventEnum.Up, e => mario.State.Jump());
            EventManager.Instance.Subscribe(EventEnum.Down, e => mario.State.Crouch());
            EventManager.Instance.Subscribe(EventEnum.Left, e => mario.State.Left());
            EventManager.Instance.Subscribe(EventEnum.Right, e => mario.State.Right());

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
            keyboardController.AddEventMapping(new BaseEvent(EventEnum.Quit), Keys.Q);
            keyboardController.AddEventMapping(new BaseEvent(EventEnum.Reset), Keys.R);
            keyboardController.AddEventMapping(new BaseEvent(EventEnum.Up), Keys.Up, Keys.W);
            keyboardController.AddEventMapping(new BaseEvent(EventEnum.Down), Keys.Down, Keys.S);
            keyboardController.AddEventMapping(new BaseEvent(EventEnum.Left), Keys.Left, Keys.A);
            keyboardController.AddEventMapping(new BaseEvent(EventEnum.Right), Keys.Right, Keys.D);
            controllers.Add(keyboardController);

            var gamePadController = new GamePadController();
            controllers.Add(gamePadController);
        }
    }
}
