using Microsoft.Xna.Framework.Input;
using System;

namespace MarioPirates
{
    using Controller;

    [Flags]
    internal enum GameMarioStatePending : uint
    {
        None = 0,
        Reset = 1,
        GameWin = 3,
        GameOver = 7,
    }

    internal static class GameMarioStatePendingHandler
    {
        public static void Handle(this GameMarioStatePending pending, GameMario game)
        {
            switch (pending)
            {
                case GameMarioStatePending.GameOver:
                    GameOver(game);
                    break;
                case GameMarioStatePending.GameWin:
                    GameWin(game);
                    break;
                case GameMarioStatePending.Reset:
                    Reset();
                    break;
            }
        }

        private static void GameOver(GameMario game)
        {
            Scene.Ins.Active(Constants.GAMEOVER_SCENE);
            Scene.Ins.ResetActive();
            game.State = new GameMarioStateEnd(game);
            EventManager.Ins.RaiseEvent(EventEnum.Action, game, new ActionEventArgs(() => GameOverReset(game)), Constants.RESET_EVENT_DT);
        }

        public static void GameOverReset(this GameMario game)
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
            Timer.Ins.Reset();
            HUD.Ins.Reset();

            game.State = new GameMarioStateNormal(game);

            EventManager.Ins.Subscribe(EventEnum.GameOver, () => game.State.TriggerGameOver());

            EventManager.Ins.Subscribe(EventEnum.Win, () => game.State.TriggerGameWin());

            EventManager.Ins.Subscribe(EventEnum.KeyDown, (s, e) =>
            {
                switch ((e as KeyDownEventArgs).key)
                {
                    case Keys.Q:
                        game.Exit();
                        break;
                    case Keys.R:
                        game.State.TriggerReset();
                        break;
                    case Keys.Escape:
                        game.State.Pause();
                        break;
                    case Keys.M:
                        if (AudioManager.Ins.IsMuted)
                            AudioManager.Ins.Unmute();
                        else
                            AudioManager.Ins.Mute();
                        break;
                }
            });

            game.Controllers.Clear();
            var keyboardController = new GameKeyboardController();
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
            game.Controllers.Add(keyboardController);

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
            game.Controllers.Add(gamePadController);
        }

        private static void GameWin(GameMario game)
        {
            Scene.Ins.Active(Constants.WIN_SCENE);
            Scene.Ins.ResetActive();
            game.State = new GameMarioStateEnd(game);
            EventManager.Ins.RaiseEvent(EventEnum.KeyDown, game, new KeyDownEventArgs(Keys.Q), Constants.RESET_EVENT_DT);
        }

        private static void Reset()
        {
            Camera.Ins.Reset();
            Scene.Ins.ResetActive();
            Scene.Ins.Player.Reset();

            Coins.Ins.Reset();
            Score.Ins.Reset();
            Timer.Ins.Reset();
        }
    }
}
