using Microsoft.Xna.Framework.Input;

namespace MarioPirates.Event
{

    internal class KeyDownEvent : IEvent
    {
        public EventEnum EventType => EventEnum.KeyDown;

        public Keys Key { get; private set; }

        public KeyDownEvent(Keys key) => Key = key;
    }

}
