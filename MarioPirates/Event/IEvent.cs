namespace MarioPirates.Event
{
    internal interface IEvent
    {
        EventEnum EventType { get; }
    }
}
