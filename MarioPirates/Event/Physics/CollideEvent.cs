namespace MarioPirates.Event
{
    internal class CollideEvent : IEvent
    {
        public EventEnum EventType => EventEnum.Collide;

        public GameObject Object1 { get; private set; }
        public GameObject Object2 { get; private set; }

        public CollideEvent(GameObject o1, GameObject o2)
        {
            Object1 = o1;
            Object2 = o2;
        }
    }
}
