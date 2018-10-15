namespace MarioPirates.Event
{
    internal class CollideEvent : IEvent
    {
        public EventEnum EventType => EventEnum.Collide;

        public readonly GameObject object1;
        public readonly GameObject object2;

        public readonly CollisionSide side;
        public readonly float depth;

        public CollideEvent(GameObject object1, GameObject object2, CollisionSide side, float depth)
        {
            this.object1 = object1;
            this.object2 = object2;
            this.side = side;
            this.depth = depth;
        }
    }
}
