using Microsoft.Xna.Framework.Input;

namespace MarioPirates.Event
{

    internal class KeyDownEvent : IEvent
    {
        public EventEnum EventType => EventEnum.KeyDown;

        public readonly Keys key;

        public KeyDownEvent(Keys key) => this.key = key;
    }

}
