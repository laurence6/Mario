using Microsoft.Xna.Framework.Input;

namespace MarioPirates.Event
{
    internal class GamePadEvent
    {
        public EventEnum EventType { get => EventEnum.Button; }

        public InputState State { get; private set; }
        public Buttons Button { get; private set; }

        public GamePadEvent(Buttons b, InputState state)
        {
            Button = b;
            State = state;
        }
    }
}
