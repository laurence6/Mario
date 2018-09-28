namespace MarioPirates.Event
{
    internal class BaseEvent : IEvent
    {
        public EventEnum EventType { get; protected set; }

        public BaseEvent(EventEnum EventType) => this.EventType = EventType;
    }
}
