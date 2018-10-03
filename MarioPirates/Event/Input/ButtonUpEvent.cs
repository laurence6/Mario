using Microsoft.Xna.Framework.Input;

namespace MarioPirates.Event
{

    internal class ButtonUpEvent : IEvent
    {
        public EventEnum EventType => EventEnum.ButtonUp;

        public Buttons Button { get; }

        public ButtonUpEvent(Buttons b) => Button = b;
    }

}
