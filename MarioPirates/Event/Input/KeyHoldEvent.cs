using Microsoft.Xna.Framework.Input;

namespace MarioPirates.Event
{

    internal class KeyHoldEvent : IEvent
    {
        public EventEnum EventType => EventEnum.KeyHold;

        public Keys Key { get; private set; }

        public KeyHoldEvent(Keys key) => Key = key;
    }

}
