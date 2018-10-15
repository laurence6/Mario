namespace MarioPirates.Event
{
    internal class GameObjectDestroyEvent : IEvent
    {
        public EventEnum EventType => EventEnum.GameObjectDestroy;

        public GameObject Object { get; private set; }

        public GameObjectDestroyEvent(GameObject o) => Object = o;
    }
}
