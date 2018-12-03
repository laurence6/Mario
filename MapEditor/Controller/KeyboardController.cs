using Microsoft.Xna.Framework.Input;

namespace MarioPirates.Controller
{
    using static Common;

    internal class KeyboardController : IController
    {
        private KeyboardState prevState, currState;

        public void Update()
        {
            currState = Keyboard.GetState();

            EnumValues<Keys>().ForEach(k =>
            {
                var state = GetPrevKeyState(k) | GetCurrKeyState(k);
                switch (state)
                {
                    case InputState.Down:
                        EventManager.Ins.RaiseEvent(EventEnum.KeyDown, this, new KeyDownEventArgs(k));
                        break;
                    case InputState.Up:
                        EventManager.Ins.RaiseEvent(EventEnum.KeyUp, this, new KeyUpEventArgs(k));
                        break;
                    case InputState.Hold:
                        EventManager.Ins.RaiseEvent(EventEnum.KeyHold, this, new KeyHoldEventArgs(k));
                        break;
                }
            });

            prevState = currState;
        }

        private InputState GetPrevKeyState(Keys k) => prevState.IsKeyDown(k) ? InputState.Up : InputState.None;
        private InputState GetCurrKeyState(Keys k) => currState.IsKeyDown(k) ? InputState.Down : InputState.None;
    }
}
