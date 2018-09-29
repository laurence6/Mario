using Microsoft.Xna.Framework.Input;

namespace MarioPirates.Controller
{
    using Event;

    internal static class InputEventFactory
    {
        public static IEvent CreateKeyEvent(InputState state, Keys key)
        {
            switch (key)
            {
                case Keys.Up:
                case Keys.W:
                    return new BaseEvent(state == InputState.Down ? EventEnum.KeyUpDown : EventEnum.KeyUpUp);
                case Keys.Down:
                case Keys.S:
                    return new BaseEvent(state == InputState.Down ? EventEnum.KeyDownDown : EventEnum.KeyDownUp);
                case Keys.Left:
                case Keys.A:
                    return new BaseEvent(state == InputState.Down ? EventEnum.KeyLeftDown : EventEnum.KeyLeftUp);
                case Keys.Right:
                case Keys.D:
                    return new BaseEvent(state == InputState.Down ? EventEnum.KeyRightDown : EventEnum.KeyRightUp);
                default:
                    return state == InputState.Down ? (IEvent)new KeyDownEvent(key) : (IEvent)new KeyUpEvent(key);
            }
        }

        public static IEvent CreateButtonEvent(InputState state, Buttons button)
        {
            // TODO
            return null;
        }
    }
}
