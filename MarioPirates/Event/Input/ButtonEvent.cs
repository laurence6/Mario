using Microsoft.Xna.Framework.Input;

namespace MarioPirates.Event
{
    internal class ButtonDownEvent : IEvent
    {
        public EventEnum EventType { get => EventEnum.ButtonDown; }

        public Buttons Button { get; }

        public ButtonDownEvent(Buttons b) => Button = b;
    }

    internal class ButtonUpEvent : IEvent
    {
        public EventEnum EventType { get => EventEnum.ButtonUp; }

        public Buttons Button { get; }

        public ButtonUpEvent(Buttons b) => Button = b;
    }
}
