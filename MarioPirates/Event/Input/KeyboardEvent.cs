using Microsoft.Xna.Framework.Input;

namespace MarioPirates.Event
{
    internal class KeyboardEvent
    {
        public EventEnum EventType { get => EventEnum.Key; }

        public InputState State { get; private set; }
        public Keys Key { get; private set; }

        public KeyboardEvent(Keys key, InputState state)
        {
            Key = key;
            State = state;
        }
    }
}
