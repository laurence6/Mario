using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace MarioPirates
{
    using Controller;
    internal class GameMario : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private List<IController> controllers = new List<IController>();

        private bool pause;
        private bool gameOver;
        private bool gameWin;

        public GameMario()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = Constants.CONTENT_ROOT;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            graphics.IsFullScreen = false;
            base.Initialize();

            spriteBatch = new SpriteBatch(GraphicsDevice);
            SpriteFactory.Ins.LoadContent(Content);

            GameOverReset();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            SpriteFactory.Ins.LoadContent(Content);
            AudioManager.Ins.LoadContent(Content);
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
            if (triggerGameOver)
            {
                GameOver();
                return;
            }

            if (triggerReset)
            {
                Reset();
                return;
            }

            if (triggerGameWin)
            {
                GameWin();
                return;
            }

            controllers.ForEach(c => c.Update());
            if (!pause)
            {
                Time.Update(gameTime);
                EventManager.Ins.Update();
                Scene.Ins.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            Scene.Ins.Draw(spriteBatch);
            if (!gameOver && !gameWin)
                HUD.Ins.Draw(spriteBatch);
        }

        private bool triggerReset = false;

        public void TriggerReset() => triggerReset = true;

        private void Reset()
        {
            Camera.Ins.Reset();
            Scene.Ins.ResetActive();
            Scene.Ins.Player.Reset();
            triggerReset = false;

            Coins.Ins.Reset();
            Score.Ins.Reset();
            Timer.Ins.Reset(Time.Now);
        }

        private bool triggerGameOver = false;

        public void TriggerGameOver() => triggerGameOver = true;

        private void GameOver()
        {
            Scene.Ins.Active(Constants.GAMEOVER_SCENE);
            Scene.Ins.ResetActive();
            gameOver = true;
            EventManager.Ins.RaiseEvent(EventEnum.Action, this, new ActionEventArgs(GameOverReset), Constants.RESET_EVENT_DT);
            triggerGameOver = false;
            triggerReset = false;
        }

        private void GameOverReset()
        {
            Physics.Reset();
            EventManager.Ins.Reset();
            Camera.Ins.Reset();
            Scene.Ins.Reset();
            Scene.Ins.Active(Constants.DEFAULT_SCENE);
            Scene.Ins.ResetActive();

            Coins.Ins.Reset();
            Score.Ins.Reset();
            Lives.Ins.Reset();
            Timer.Ins.Reset(Time.Now, 400000);
            HUD.Ins.Reset();

            EventManager.Ins.Subscribe(EventEnum.GameOver, (s, e) => TriggerGameOver());

            EventManager.Ins.Subscribe(EventEnum.Win, (s, e) => TriggerGameWin());

            EventManager.Ins.Subscribe(EventEnum.KeyDown, (s, e) =>
            {
                switch ((e as KeyDownEventArgs).key)
                {
                    case Keys.Q:
                        Exit();
                        break;
                    case Keys.R:
                        TriggerReset();
                        break;
                    case Keys.Escape:
                        pause = !pause;
                        break;
                    case Keys.M:
                        if (AudioManager.Ins.IsMuted)
                        {
                            AudioManager.Ins.Unmute();
                        }
                        else
                        {
                            AudioManager.Ins.Mute();
                        }
                        break;
                }
            });

            controllers.Clear();
            triggerGameOver = false;
            triggerReset = false;
            pause = false;
            gameOver = false;
            gameWin = false;
            var keyboardController = new KeyboardController();
            keyboardController.SetKeyMapping(Keys.LeftShift, Keys.X);
            keyboardController.SetKeyMapping(Keys.RightShift, Keys.X);
            keyboardController.SetKeyMapping(Keys.Space, Keys.Up);
            keyboardController.SetKeyMapping(Keys.Z, Keys.Up);
            keyboardController.SetKeyMapping(Keys.W, Keys.Up);
            keyboardController.SetKeyMapping(Keys.S, Keys.Down);
            keyboardController.SetKeyMapping(Keys.A, Keys.Left);
            keyboardController.SetKeyMapping(Keys.D, Keys.Right);
            keyboardController.EnableKeyEvent(InputState.Down, Keys.Q, Keys.R, Keys.Escape, Keys.M);
            keyboardController.EnableKeyEvent(InputState.Down, Keys.Up, Keys.Down, Keys.Left, Keys.Right, Keys.X);
            keyboardController.EnableKeyEvent(InputState.Up, Keys.Up, Keys.Down, Keys.Left, Keys.Right, Keys.X);
            keyboardController.EnableKeyEvent(InputState.Hold, Keys.Up, Keys.Down, Keys.Left, Keys.Right, Keys.X);
            keyboardController.EnableKeyEvent(InputState.Down, Keys.Y, Keys.U, Keys.I, Keys.O, Keys.P);
            controllers.Add(keyboardController);

            var gamePadController = new GamePadController();
            gamePadController.EnableButtonEvent(InputState.Down, Buttons.Start);
            gamePadController.EnableButtonEvent(InputState.Down,
                Buttons.LeftThumbstickDown,
                Buttons.LeftThumbstickLeft,
                Buttons.LeftThumbstickRight,
                Buttons.A,
                Buttons.B
            );
            gamePadController.EnableButtonEvent(InputState.Hold,
                Buttons.LeftThumbstickDown,
                Buttons.LeftThumbstickLeft,
                Buttons.LeftThumbstickRight,
                Buttons.A,
                Buttons.B
            );
            gamePadController.EnableButtonEvent(InputState.Up,
                Buttons.LeftThumbstickDown,
                Buttons.LeftThumbstickLeft,
                Buttons.LeftThumbstickRight,
                Buttons.A,
                Buttons.B
            );
            controllers.Add(gamePadController);
        }

        private bool triggerGameWin = false;

        public void TriggerGameWin() => triggerGameWin = true;

        private void GameWin()
        {
            Scene.Ins.Active(Constants.WIN_SCENE);
            Scene.Ins.ResetActive();
            triggerGameWin = false;
            gameWin = true;
        }
    }
}
