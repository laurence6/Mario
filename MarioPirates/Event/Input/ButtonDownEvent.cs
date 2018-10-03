using Microsoft.Xna.Framework.Input;

namespace MarioPirates.Event
{

    internal class ButtonDownEvent : IEvent
    {
        public EventEnum EventType => EventEnum.ButtonDown;

        public Buttons Button { get; }

        public ButtonDownEvent(Buttons b) => Button = b;
    }

}
