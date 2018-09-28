using Microsoft.Xna.Framework.Input;

namespace MarioPirates.Event
{
    internal class KeyDownEvent : IEvent
    {
        public EventEnum EventType { get => EventEnum.KeyDown; }

        public Keys Key { get; private set; }

        public KeyDownEvent(Keys key) => Key = key;
    }

    internal class KeyUpEvent : IEvent
    {
        public EventEnum EventType { get => EventEnum.KeyUp; }

        public Keys Key { get; private set; }

        public KeyUpEvent(Keys key) => Key = key;
    }
}
