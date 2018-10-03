using Microsoft.Xna.Framework.Input;

namespace MarioPirates.Event
{

    internal class KeyUpEvent : IEvent
    {
        public EventEnum EventType => EventEnum.KeyUp;

        public Keys Key { get; private set; }

        public KeyUpEvent(Keys key) => Key = key;
    }

}
