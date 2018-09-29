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
            switch (state)
            {
                case InputState.Down:
                    return new KeyDownEvent(key);
                case InputState.Up:
                    return new KeyUpEvent(key);
                case InputState.Hold:
                    return new KeyHoldEvent(key);
            }
            return null;
        }

        public static IEvent CreateButtonEvent(InputState state, Buttons button)
        {
            // TODO
            return null;
        }
    }
}
