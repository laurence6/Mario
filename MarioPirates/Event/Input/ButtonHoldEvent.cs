using Microsoft.Xna.Framework.Input;

namespace MarioPirates.Event
{

    internal class ButtonHoldEvent : IEvent
    {
        public EventEnum EventType => EventEnum.ButtonHold;

        public Buttons Button { get; }

        public ButtonHoldEvent(Buttons b) => Button = b;
    }

}
