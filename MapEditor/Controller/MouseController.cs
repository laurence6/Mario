using Microsoft.Xna.Framework.Input;

namespace MarioPirates.Controller
{
    internal class MouseController : IController
    {
        private MouseState prevState, currState;
        
        public void Update()
        {
            currState = Mouse.GetState();
            var state = GetPrevButtonState(prevState.LeftButton) | GetCurrButtonState(currState.LeftButton);
            switch (state)
            {
                case InputState.Down:
                    EventManager.Ins.RaiseEvent(EventEnum.MouseButtonDown, this, new MouseButtonDownEventArgs(currState.Position));
                    break;
                case InputState.Up:
                    EventManager.Ins.RaiseEvent(EventEnum.MouseButtonUp, this, new MouseButtonUpEventArgs(currState.Position));
                    break;
                case InputState.Hold:
                    EventManager.Ins.RaiseEvent(EventEnum.MouseButtonHold, this, new MouseButtonHoldEventArgs(currState.Position));
                    break;
            };

            prevState = currState;
        }

        private InputState GetPrevButtonState(ButtonState k) => k is ButtonState.Pressed ? InputState.Up : InputState.None;
        private InputState GetCurrButtonState(ButtonState k) => k is ButtonState.Pressed ? InputState.Down : InputState.None;
    }
}
