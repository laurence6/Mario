using Microsoft.Xna.Framework.Input;
using System;

namespace MarioPirates.Controller
{
    using Event;

    internal static class InputEventFactory
    {
        public static IEvent CreateKeyEvent(InputState state, Keys key)
        {
            if (Enum.TryParse<EventEnum>("Key" + key.ToString() + state.ToString(), out var e))
            {
                return new BaseEvent(e);
            }
            //
            switch (state)
            {
                case InputState.Down:
                    return new KeyDownEvent(key);
            }
            return null;
        }

        public static IEvent CreateButtonEvent(Buttons button)
        {
            switch (button)
            {
                case Buttons.LeftThumbstickUp:
                    return new BaseEvent(EventEnum.KeyUpHold);
                case Buttons.LeftThumbstickDown:
                    return new BaseEvent(EventEnum.KeyDownHold);
                case Buttons.LeftThumbstickLeft:
                    return new BaseEvent(EventEnum.KeyLeftHold);
                case Buttons.LeftThumbstickRight:
                    return new BaseEvent(EventEnum.KeyRightHold);
            }
            return null;
        }
    }
}
